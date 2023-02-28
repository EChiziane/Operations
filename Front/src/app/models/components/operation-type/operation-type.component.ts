import {Component, TemplateRef} from '@angular/core';
import {OperationTypeService} from "../../../services/operation-type.service";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {OperationType} from "../../operationType";

@Component({
  selector: 'app-operation-type',
  templateUrl: './operation-type.component.html',
  styleUrls: ['./operation-type.component.css']
})
export class OperationTypeComponent {
  public operationTypes: OperationType[] = [];
  public operationTypesFiltrados: OperationType[] = [];
  modalRef?: BsModalRef;
  private filtroListado = '';

  constructor(private operationTypeService: OperationTypeService,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.operationTypesFiltrados = this.filtroLista ? this.filtrarOperationTypes(this.filtroLista) : this.operationTypes;
  }

  ngOnInit(): void {
    this.getOperationTypes()
  }

  public filtrarOperationTypes(filtrarPor: string): OperationType[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.operationTypes.filter(
      (operationTypes: { description: string; }) => operationTypes.description.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }


  public getOperationTypes(): void {
    this.operationTypeService.getOperationTypes().subscribe({
      next: (operationTypes: OperationType[]) => {
        this.operationTypes = operationTypes;
        this.operationTypesFiltrados = this.operationTypes

      },
      error: (erro: any) => {
        alert("No Data")
      }
    })

  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }


}
