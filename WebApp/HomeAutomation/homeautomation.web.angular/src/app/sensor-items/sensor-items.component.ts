import { Component, OnInit } from '@angular/core';
import { Sensor } from '../api/models/Sensor';
import { SensorApi } from '../api/resources/SensorApi';

@Component({
  selector: 'app-sensor-items',
  templateUrl: './sensor-items.component.html',
  styleUrls: ['./sensor-items.component.css']
})

export class SensorItemsComponent implements OnInit {
  public sensors: Sensor[] = [];
  public id: number = 0;

  constructor(private sensorApi: SensorApi) { }

  ngOnInit(): void {
    this.loadAllSensors();
  }

  setId(id: number) {
    this.id = id;
  }

  deleteSensor(id: number) {
    this.sensorApi.Delete(id).subscribe(() => this.loadAllSensors())
  }

  loadAllSensors() {
    console.log("asd2");

    this.sensorApi.LoadAll().subscribe((data: any) => {
      this.sensors = data.values;
    });
  }

  displayedColumns: string[] = ['name', 'sensorTypeID', 'codeVersion', 'edit', 'delete'];
}
