import {Component, TemplateRef} from '@angular/core';
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {OperationService} from "../../../services/operation.service";
import {Operation} from "../../operation";

@Component({
  selector: 'app-operation',
  templateUrl: './operation.component.html',
  styleUrls: ['./operation.component.css']
})
export class OperationComponent {
  modalRef?: BsModalRef;
  public operations: Operation[]=[];
  public operationsFiltrados: Operation[] = [];
  private filtroListado = '';

  constructor(private modalService: BsModalService,private operationService:OperationService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.operationsFiltrados = this.filtroLista ? this.filtrarOperations(this.filtroLista) : this.operations;
  }

  ngOnInit(): void {
    this.getOperations()

  }

  public getOperations(): void {
   this.operationService.getOperation().subscribe({
     next:(operatios:Operation[])=>{
       this.operations=operatios;
       console.log(this.operations)
       this.operationsFiltrados=this.operations;
     },
     error:(error:any)=>{
       console.log(error);
     },
   })
  }

  public filtrarOperations(filtrarPor: string): Operation[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.operations.filter(
      operation => operation.description.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  //Modal
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    // this.toastr.success('O Evento foi deletado com Sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
