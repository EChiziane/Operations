import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Material} from "../Models/Material";

@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  baseURL= 'https://localhost:5001/api/Material';
  constructor(private http:HttpClient) { }

  public getMaterial():Observable<Material[]>{
    return this.http.get<Material[]>(this.baseURL);
  }

  public getMaterialById(id: number): Observable<Material> {
    return this.http.get<Material>(`${this.baseURL}/${id}`);
  }
}