import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Destination} from "../Models/Destination";

@Injectable({
  providedIn: 'root'
})
export class DestinationService {

  baseURL= 'https://localhost:5001/api/Destination';
  constructor(private http:HttpClient) { }

  public getDestination():Observable<Destination[]>{
    return this.http.get<Destination[]>(this.baseURL);
  }

  public getDestinationById(id: number): Observable<Destination> {
    return this.http.get<Destination>(`${this.baseURL}/${id}`);
  }

  public getDestinationByCode(code: string): Observable<Destination[]> {
    return this.http.get<Destination[]>(`${this.baseURL}/code/${code}`);
  }
}
