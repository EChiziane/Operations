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
  displayedColumns: string[] = ['Id', 'Destination', 'Driver', 'Client', 'Status', 'Amount', 'Date', 'Edit'];
  private filtroListado = '';
  private carloadId = 0;

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
      carload => carload.client.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        carload.client.lastName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit(): void {
    this.getCarLoads()
  }

  public getCarLoads(): void {
    this.carloadService.getCarLoads().subscribe({
      next: (carloads: CarLoad[]) => {
        this.carloads = carloads;
        this.carloadsFiltrados = this.carloads
      },
      error: (error: any) => {

      },
    })
  }


  openModal(template: TemplateRef<any>, carloadId: number): void {
    this.carloadId = carloadId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public deleteCarload(id: number) {
    this.carloadService.DeleteCarLoad(id)
      .subscribe(carload => {
        this.getCarLoads()
      })
  }


  confirm(selected: number): void {
    if (selected == 1) {
      this.deleteCarload(this.carloadId)
      this.modalRef?.hide();
    }
  }

  decline(): void {
    this.modalRef?.hide();
  }


}
