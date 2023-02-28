import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {OperationType} from "../models/operationType";

@Injectable({
  providedIn: 'root'
})
export class OperationTypeService {
  baseURL = 'https://localhost:5001/api/OperationType';

  constructor(private http: HttpClient) {
  }

  public getOperationTypes(): Observable<OperationType[]> {
    return this.http.get<OperationType[]>(this.baseURL);
  }

  public getOperationTypesByDescription(description: string): Observable<OperationType[]> {
    return this.http.get<OperationType[]>(`${this.baseURL}/${description}/description`);
  }

  public getOperationTypeById(id: number): Observable<OperationType> {
    return this.http.get<OperationType>(`${this.baseURL}/${id}`);
  }
}
