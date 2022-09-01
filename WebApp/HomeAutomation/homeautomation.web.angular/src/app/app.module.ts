import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { MatTableModule } from '@angular/material/table';

import { AppComponent } from './app.component';
import { SensorItemsComponent } from './sensor-items/sensor-items.component';
import { SensorApi } from './api/resources/SensorApi';
import { SensorItemComponent } from './sensor-item/sensor-item.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    SensorItemsComponent,
    SensorItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [SensorApi],
  bootstrap: [AppComponent]
})
export class AppModule { }
