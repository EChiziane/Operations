import { Component } from '@angular/core';
import {Material} from "../../Models/Material";
import {MaterialService} from "../../services/material.service";

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent {
  public materials: Material[] = [];
  public materialsFiltrados: Material[] = [];
  private filtroListado = '';

  constructor(private materialService: MaterialService) {
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
  public ngOnInit():void{
    this.getMaterials()
  }

  public getMaterials():void{
    this.materialService.getMaterial().subscribe({
      next:(meterialTypes:Material[])=>{
        this.materials=meterialTypes;
        this.materialsFiltrados=this.materials
      },
      error:(error:any)=>{

      },
    })
  }
}
