import {Component, OnInit, TemplateRef} from '@angular/core';
import {Destination} from "../../Models/Destination";
import {DestinationService} from "../../services/destination.service";
import {MatDialog} from "@angular/material/dialog";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";

@Component({
  selector: 'app-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.css']
})
export class DestinationComponent implements OnInit{
  modalRef?: BsModalRef;
  public destinations: Destination[] = [];
  public destinationsFiltrados: Destination[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'Code', 'Description', 'Edit'];
private destinationId=0;

  constructor(private destinationService: DestinationService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
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

  public deleteDestination(id:number):void{
    this.destinationService.deleteDestination(id)
      .subscribe(destination=>
        this.getDestinations())
  }

  openModal(template: TemplateRef<any>, destinationId:number): void {
    this.destinationId=destinationId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(selected:number): void {
    if(selected==1)
     this.deleteDestination(this.destinationId)
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }


}
