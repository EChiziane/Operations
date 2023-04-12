import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, take} from "rxjs";
import {Material} from "../Models/Material";
import {MaterialType} from "../Models/Material Type";

@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  baseURL= 'https://localhost:5001/api/Material';
  constructor(private http:HttpClient) { }

  public getMaterial():Observable<Material[]>{
    return this.http.get<Material[]>(this.baseURL);
  }

  public DeleteMaterial(id:number):Observable<Material>{
    return this.http.delete<Material>(`${this.baseURL}/${id}`).pipe(take(1))
  }


  public getMaterialById(id: number): Observable<Material> {
    return this.http.get<Material>(`${this.baseURL}/${id}`);
  }
}
