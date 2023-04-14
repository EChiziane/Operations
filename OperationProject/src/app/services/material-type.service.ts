import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, take} from "rxjs";
import {MaterialType} from "../Models/Material Type";

@Injectable({
  providedIn: 'root'
})
export class MaterialTypeService {
baseURL= 'https://localhost:5001/api/MaterialType';
  constructor(private http:HttpClient) { }

  public getMaterialType():Observable<MaterialType[]>{
    return this.http.get<MaterialType[]>(this.baseURL);
  }

  public DeleteMaterialType(id:number):Observable<MaterialType>{
    return this.http.delete<MaterialType>(`${this.baseURL}/${id}`).pipe(take(1))
  }

  public getMaterialTypeById(id: number): Observable<MaterialType> {
    return this.http.get<MaterialType>(`${this.baseURL}/${id}`);
  }

  public getMaterialTypeByCode(code: string): Observable<MaterialType[]> {
    return this.http.get<MaterialType[]>(`${this.baseURL}/code/${code}`);
  }
  public addMaterial(materialType:MaterialType):Observable<MaterialType>{
    return  this.http.post<MaterialType>(this.baseURL,materialType).pipe(take(1));
  }
}
