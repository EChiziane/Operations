import {Component, TemplateRef} from '@angular/core';
import {Material} from "../../Models/Material";
import {MaterialService} from "../../services/material.service";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent {
  modalRef?: BsModalRef;
  selected = 'option2';
  public materials: Material[] = [];
  public materialsFiltrados: Material[] = [];
  private filtroListado = '';
  displayedColumns: string[] = ['Id', 'Price', 'Description', 'Edit'];


  constructor(private materialService: MaterialService,
              public dialog: MatDialog,
              private modalService: BsModalService) {
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.materialsFiltrados = this.filtroLista ? this.filtrarMaterial(this.filtroLista) : this.materials;
  }

  public filtrarMaterial(filtrarPor: string): Material[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.materials.filter(
      material => material.materialType.description.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit(): void {
    this.getMaterials()
  }

  public getMaterials(): void {
    this.materialService.getMaterial().subscribe({
      next: (meterialTypes: Material[]) => {
        this.materials = meterialTypes;
        this.materialsFiltrados = this.materials
      },
      error: (error: any) => {

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
