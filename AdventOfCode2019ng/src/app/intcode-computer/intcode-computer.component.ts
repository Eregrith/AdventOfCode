import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-intcode-computer',
  templateUrl: './intcode-computer.component.html',
  styleUrls: ['./intcode-computer.component.css']
})
export class IntcodeComputerComponent implements OnInit {

  private _hubConnection: HubConnection;
  _console: string[] = [];
  _result: string;
  _context: IntcodeContext;
  _contextDataLines: BigInteger[][];
  _currentOpcode: Opcode;
  _targets: BigInteger[];
  _params: number[];
  _files: string[];
  file: string;
  input: string;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.createConnection();
    this.connect();

    this._hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
      if (type === "intcode_console")
        this._console.push(payload);
      else if (type === "intcode_result")
        this._result = payload.split("\r\n").join("<br/>");
    });
    this._hubConnection.on('Step', (context: IntcodeContext, currentOpcode: Opcode) => {
      this._context = context;
      this._currentOpcode = currentOpcode;
      console.log("Context:", context);
      console.log("CurrentOpcode:", currentOpcode);
      this.refreshContextDataLines();
    });

    this._hubConnection.onclose(() => { 
      setTimeout(this.reconnect,3000); 
     });

    this.getAvailableFiles();
  }

  refreshContextDataLines() {
    let lines: any[][] = [];
    for (let l = 0; l < 32; l++) {
      let line : any[] = [];
      for (let c = 0; c < 64; c++) {
        line.push({ value: this._context.data[l * 64 + c], index: l*64+c});
      }
      lines.push(line);
    }
    this._contextDataLines = lines;
    this._targets = [];
    this._params = [];
    for (let param = 1; param <= this._currentOpcode.params; param++) {
      let mode = this.getParamMode(this._context.data, this._context.instructionPointer, param);
      let target: BigInteger;
      if (mode == 0) {
        target = this._context.data[this._context.instructionPointer + param];
      } else if (mode == 1) {
        target = (this._context.instructionPointer + param) as unknown as BigInteger;
      } else if (mode == 2) {
        target = (this._context.data[this._context.instructionPointer + param] as unknown as number)
                 + (this._context.relativeBase as unknown as number) as unknown as BigInteger;
      }
      this._targets.push(target);
      this._params.push(mode);
    }
  }

  getParamMode(data: BigInteger[], ip: number, offset: number) : number {
    let opcode:number = data[ip] as unknown as number;
    return Math.round(opcode / (10 * (10 ** offset)) % 10);
  }

  clean() {
    this._console = [];
    this._result = undefined;
  }

  getAvailableFiles() {
    this.http.get<string[]>('http://localhost:56503/api/IntcodeDay5/GetIntcodeFiles').subscribe(response => {
      this._files = response;
    });
  }

  start() {
    this._console.push("Starting file " + this.file + "...");
    this.http.post('http://localhost:56503/api/IntcodeDay5/Start', { File: this.file }).subscribe(response => {
      console.log("Got response from Start");
    });
  }

  sendInput() {
    this._console.push("Sending input " + this.input + "...");
    this.http.post('http://localhost:56503/api/IntcodeDay5/SendInput', { Input: Number.parseInt(this.input) }).subscribe(response => {
      console.log("Got response from SendInput");
      this._context.inputQueue.push(Number.parseInt(this.input) as unknown as BigInteger);
      this.input = undefined;
    });
  }

  step() {
    this.http.get('http://localhost:56503/api/IntcodeDay5/Step').subscribe(response => {
      console.log("Got response from Step");
    });
  }

  createConnection(): void {
    this._hubConnection = new HubConnectionBuilder().withUrl('http://localhost:56503/intcode').build();
  }

  connect():void {
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => { console.log('Error while establishing connection :('); setTimeout(() => this.reconnect(), 3000); });
  }

  reconnect():void {
    if (this._hubConnection === undefined) {
      this.createConnection();
    } else {
      console.log('_hubConnection is not undefined');
    }
    console.log('Trying to reconnect...');
    this.connect();
  }
}
