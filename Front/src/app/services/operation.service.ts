import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {OperationType} from "../models/operationType";
import {Operation} from "../models/operation";

@Injectable({
  providedIn: 'root'
})
export class OperationService {
  baseURL = 'https://localhost:5001/api/Operation';
  constructor(private http: HttpClient) {
  }

  public getOperation(): Observable<Operation[]> {
    return this.http.get<Operation[]>(this.baseURL);
  }
}
