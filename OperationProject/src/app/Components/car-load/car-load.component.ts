import {Component, TemplateRef} from '@angular/core';
import {CarLoad} from "../../Models/CarLoad";
import {CarLoadService} from "../../services/car-load.service";
import {MatDialog} from "@angular/material/dialog";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";

@Component({
  selector: 'app-car-load',
  templateUrl: './car-load.component.html',
  styleUrls: ['./car-load.component.css']
})
export class CarLoadComponent {

  modalRef?: BsModalRef;
  public carloads: CarLoad[] = [];
  public carloadsFiltrados: CarLoad[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'Destination', 'Driver','Client', 'Status','Amount','Date','Edit'];

  constructor(private carloadService: CarLoadService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.carloadsFiltrados = this.filtroLista ? this.filtrarCarLoad(this.filtroLista) : this.carloads;
  }

  public filtrarCarLoad(filtrarPor: string): CarLoad[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.carloads.filter(
      carload => carload.client.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1||
        carload.client.lastName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit():void{
    this.getCarLoads()
  }

  public getCarLoads():void{
    this.carloadService.getCarLoads().subscribe({
      next:(carloads:CarLoad[])=>{
        this.carloads=carloads;
        this.carloadsFiltrados=this.carloads
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