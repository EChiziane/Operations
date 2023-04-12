import { Injectable } from '@angular/core';

import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {Driver} from "../Models/driver";


@Injectable({
  providedIn: 'root'
})
export class DriverService {

  baseURL= 'https://localhost:5001/api/Driver';
  constructor(private http:HttpClient) { }

  public getDriver():Observable<Driver[]>{
    return this.http.get<Driver[]>(this.baseURL);
  }

  public getDriverById(id: number): Observable<Driver> {
    return this.http.get<Driver>(`${this.baseURL}/${id}`);
  }
}
