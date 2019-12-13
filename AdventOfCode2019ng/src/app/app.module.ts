import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { GrowlModule } from 'primeng/primeng';
import { AppComponent } from './app.component';
import { IntcodeComputerComponent } from './intcode-computer/intcode-computer.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    IntcodeComputerComponent
  ],
  imports: [
    BrowserModule,
    GrowlModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
