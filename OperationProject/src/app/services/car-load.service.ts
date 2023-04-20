import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, take} from "rxjs";
import {CarLoad} from "../Models/CarLoad";


@Injectable({
  providedIn: 'root'
})
export class CarLoadService {
  baseURL = 'https://localhost:5001/api/carloads';

  constructor(private http: HttpClient) {
  }


  public getCarLoads(): Observable<CarLoad[]> {
    return this.http.get<CarLoad[]>(this.baseURL);
  }

  public DeleteCarLoad(id: number): Observable<CarLoad> {
    return this.http.delete<CarLoad>(`${this.baseURL}/${id}`).pipe(take(1))
  }

  public addCarload(carload: CarLoad): Observable<CarLoad> {
    return this.http.post<CarLoad>(this.baseURL,
      {
        clientId: carload.client.id,
        driverId: carload.driver.id,
        destinationId: carload.destination.id,
        materialId: carload.material.id,
        amount: carload.amount,
        date: carload.date
      })
      .pipe(take(1));
  }

}
