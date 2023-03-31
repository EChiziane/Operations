import {Component, TemplateRef} from '@angular/core';
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {ClientService} from "../../services/client.service";
import {MatDialog} from "@angular/material/dialog";
import {Client} from "../../Models/client";

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent {


  modalRef?: BsModalRef;
  public clients: Client[] = [];
  public clientsFiltrados: Client[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'FirstName', 'LastName', 'Edit'];

  constructor(private clientService: ClientService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.clientsFiltrados = this.filtroLista ? this.filtrarClient(this.filtroLista) : this.clients;
  }

  public filtrarClient(filtrarPor: string): Client[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.clients.filter(
      client => client.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1||
         client.lastName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit():void{
    this.getClients()
  }

  public getClients():void{
    this.clientService.getClient().subscribe({
      next:(clients:Client[])=>{
        this.clients=clients;
        this.clientsFiltrados=this.clients
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
