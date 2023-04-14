import {Component, TemplateRef} from '@angular/core';
import {MaterialTypeService} from "../../services/material-type.service";
import {MaterialType} from "../../Models/Material Type";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-material-type',
  templateUrl: './material-type.component.html',
  styleUrls: ['./material-type.component.css']
})
export class MaterialTypeComponent {
  modalRef?: BsModalRef;
  public materialTypes: MaterialType[] = [];
  public materialTypesFiltrados: MaterialType[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'Code', 'Description', 'Edit'];

  public materialTypeId = 0;

  constructor(private materialTypeService: MaterialTypeService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.materialTypesFiltrados = this.filtroLista ? this.filtrarMaterialType(this.filtroLista) : this.materialTypes;
  }

  public filtrarMaterialType(filtrarPor: string): MaterialType[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.materialTypes.filter(
      materialType => materialType.description.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  public ngOnInit():void{
 this.getMaterialTypes()
  }

  public getMaterialTypes():void{
    this.materialTypeService.getMaterialType().subscribe({
      next:(meterialTypes:MaterialType[])=>{
        this.materialTypes=meterialTypes;
        this.materialTypesFiltrados=this.materialTypes
      },
      error:(error:any)=>{

      },
    })
  }

  public deleteMaterialType(id:number){
    this.materialTypeService.DeleteMaterialType(id)
      .subscribe(materialType=>{
        this.getMaterialTypes()
      })
  }

  openModal(template: TemplateRef<any>, materialTypeId:number): void {
    this.materialTypeId=materialTypeId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(selected:number): void {
    if(selected==1) {
      this.deleteMaterialType(this.materialTypeId);
      this.modalRef?.hide();
    }
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
