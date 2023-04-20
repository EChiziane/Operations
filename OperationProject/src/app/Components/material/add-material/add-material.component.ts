import {Component, OnInit} from '@angular/core';
import {Material} from "../../../Models/Material";
import {MaterialType} from "../../../Models/Material Type";
import {MaterialTypeService} from "../../../services/material-type.service";
import {MaterialService} from "../../../services/material.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.css']
})
export class AddMaterialComponent implements OnInit {

  public materialType!: MaterialType;
  public materialTypes: MaterialType[] = [];
  selectedMaterialType: number = 0

  material: Material = {
    price: 0,
    materialType: this.materialType,
    id: 0
  }


  constructor(
    private materialTypeService: MaterialTypeService,
    private materialService: MaterialService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.getMaterialTypes()
  }


  public getMaterialTypes(): void {
    this.materialTypeService.getMaterialType().subscribe({
      next: (materialTypes: MaterialType[]) => {
        this.materialTypes = materialTypes;
      },
      error: (error: any) => {
      },
    })

  }

  public selectMaterialType(): void {
    this.materialTypeService.getMaterialTypeById(this.selectedMaterialType).subscribe(
      (materialType: MaterialType) => {
        this.material.materialType = materialType
      }
    );
  }

  public createMaterial(): void {
    this.materialService.addMaterial(this.material).subscribe(() => {
      this.router.navigate(['/material'])
    })
  }


}
