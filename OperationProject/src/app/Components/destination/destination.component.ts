import {Component, OnInit, TemplateRef} from '@angular/core';
import {Destination} from "../../Models/Destination";
import {DestinationService} from "../../services/destination.service";
import {MatTableDataSource} from "@angular/material/table";
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


  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(selected:number): void {
    if(selected==1)
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
