import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sensor } from '../models/Sensor';
import { APISettings } from '../config';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class SensorApi {
  constructor(private http: HttpClient) { }

  LoadAll(): Observable<Sensor[]> {
    return this.http.get<Sensor[]>(APISettings.baseURL + '/sensors');
  }

  Load(id: number): Observable<Sensor> {
    return this.http.get<Sensor>(APISettings.baseURL + '/sensors/' + id);
  }

  Create(data: Sensor): Observable<Sensor> {
    return this.http.put<Sensor>(APISettings.baseURL + '/sensors', data, httpOptions);
  }

  Update(data: Sensor): Observable<Sensor> {
    return this.http.post<Sensor>(APISettings.baseURL + '/sensors', data, httpOptions);
  }

  Delete(id: number): Observable<Sensor> {
    return this.http.delete<Sensor>(APISettings.baseURL + '/sensors/' + id, httpOptions);
  }
}
