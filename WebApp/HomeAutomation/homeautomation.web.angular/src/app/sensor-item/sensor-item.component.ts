import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Sensor } from '../api/models/Sensor';
import { SensorApi } from '../api/resources/SensorApi';

@Component({
  selector: 'app-sensor-item',
  templateUrl: './sensor-item.component.html',
  styleUrls: ['./sensor-item.component.css']
})
export class SensorItemComponent implements OnInit {
  @Input() id: number = 0;
  @Output() updateSensors = new EventEmitter();

  public sensor: Sensor = {} as Sensor;

  constructor(private sensorApi: SensorApi) { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['id'].currentValue > 0) {
      this.sensorApi.Load(changes['id'].currentValue).subscribe((data: any) => {
        this.sensor = data.value;
      });
    }
  }

  saveSensor() {
    if (this.id > 0) {
      this.sensorApi.Update(this.sensor).subscribe(() => this.updateSensors.emit());
    }
    else {
      this.sensorApi.Create(this.sensor).subscribe(() => this.updateSensors.emit());
    }
  }
}
