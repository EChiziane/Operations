import { Component } from '@angular/core';
import {Destination} from "../../Models/Destination";
import {DestinationService} from "../../services/destination.service";

@Component({
  selector: 'app-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.css']
})
export class DestinationComponent {
  public destinations: Destination[] = [];
  public destinationsFiltrados: Destination[] = [];
  private filtroListado = '';

  constructor(private destinationService: DestinationService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.destinationsFiltrados = this.filtroLista ? this.filtrarDestination(this.filtroLista) : this.destinations;
  }

  public filtrarDestination(filtrarPor: string): Destination[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.destinations.filter(
      destination => destination.description.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  public ngOnInit():void{
    this.getDestinations()
  }

  public getDestinations():void{
    this.destinationService.getDestination().subscribe({
      next:(destinations:Destination[])=>{
        this.destinations=destinations;
        this.destinationsFiltrados=this.destinations
      },
      error:(error:any)=>{

      },
    })
  }
}
