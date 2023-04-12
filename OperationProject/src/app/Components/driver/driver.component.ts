import {Component, TemplateRef} from '@angular/core';
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {DriverService} from "../../services/driver.service";
import {MatDialog} from "@angular/material/dialog";
import {Driver} from "../../Models/driver";

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.css']
})
export class DriverComponent {


  modalRef?: BsModalRef;
  public drivers: Driver[] = [];
  public driversFiltrados: Driver[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'FirstName', 'LastName', 'Edit'];

  constructor(private driverService: DriverService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.driversFiltrados = this.filtroLista ? this.filtrarDriver(this.filtroLista) : this.drivers;
  }

  public filtrarDriver(filtrarPor: string): Driver[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.drivers.filter(
      driver => driver.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1||
        driver.lastName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit():void{
    this.getDrivers()
  }

  public getDrivers():void{
    this.driverService.getDriver().subscribe({
      next:(drivers:Driver[])=>{
        this.drivers=drivers;
        this.driversFiltrados=this.drivers
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
