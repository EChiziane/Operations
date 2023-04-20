import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, take} from "rxjs";
import {Destination} from "../Models/Destination";

@Injectable({
  providedIn: 'root'
})
export class DestinationService {

  baseURL = 'https://localhost:5001/api/Destination';

  constructor(private http: HttpClient) {
  }

  public getDestination(): Observable<Destination[]> {
    return this.http.get<Destination[]>(this.baseURL);
  }

  public deleteDestination(id: number): Observable<Destination> {
    return this.http.delete<Destination>(`${this.baseURL}/${id}`);
  }

  public getDestinationById(id: number): Observable<Destination> {
    return this.http.get<Destination>(`${this.baseURL}/${id}`);
  }

  public getDestinationByCode(code: string): Observable<Destination[]> {
    return this.http.get<Destination[]>(`${this.baseURL}/code/${code}`);
  }

  public addDestination(destination: Destination): Observable<Destination> {
    return this.http.post<Destination>(this.baseURL, destination).pipe(take(1));
  }
}
