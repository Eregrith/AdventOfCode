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
  _memory: BigInteger[] = new Array<BigInteger>(2048);
  _result: string;
  _context: IntcodeContext;

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
    this._hubConnection.on('Step', (context: IntcodeContext) => {
      console.log("Context received:", context);
      this._context = context;
    });

    this._hubConnection.onclose(() => { 
      setTimeout(this.reconnect,3000); 
     });
  }

  start() {
    this._console.push("Starting...");
    this.http.get('http://localhost:56503/api/IntcodeDay5/Start');
  }

  step() {
    this._console.push("Stepping...");
    this.http.get('http://localhost:56503/api/IntcodeDay5/Step');
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
