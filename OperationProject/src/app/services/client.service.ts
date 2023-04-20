import {Injectable} from '@angular/core';
import {Client} from "../Models/client";
import {Observable, take} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseURL = 'https://localhost:5001/api/Client';

  constructor(private http: HttpClient) {
  }

  public getClient(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseURL);
  }

  public deleteClient(id: number): Observable<Client> {
    return this.http.delete<Client>(`${this.baseURL}/${id}`);
  }

  public getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.baseURL}/${id}`);
  }

  public addClient(client: Client): Observable<Client> {
    return this.http.post<Client>(this.baseURL, client).pipe(take(1));
  }
}
