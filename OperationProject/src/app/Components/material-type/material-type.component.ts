import {Component} from '@angular/core';
import {MaterialTypeService} from "../../services/material-type.service";
import {MaterialType} from "../../Models/Material Type";

@Component({
  selector: 'app-material-type',
  templateUrl: './material-type.component.html',
  styleUrls: ['./material-type.component.css']
})
export class MaterialTypeComponent {
  public materialTypes: MaterialType[] = [];
  public materialTypesFiltrados: MaterialType[] = [];
  private filtroListado = '';

  constructor(private materialTypeService: MaterialTypeService) {
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
}
