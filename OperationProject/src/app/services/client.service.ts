import { Injectable } from '@angular/core';
import {Client} from "../Models/client";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseURL= 'https://localhost:5001/api/Client';
  constructor(private http:HttpClient) { }

  public getClient():Observable<Client[]>{
    return this.http.get<Client[]>(this.baseURL);
  }

  public getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.baseURL}/${id}`);
  }
 }
