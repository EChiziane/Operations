import {Component} from "@angular/core";
import {MaterialType} from "../../../Models/Material Type";
import {Router} from "@angular/router";
import {MaterialTypeService} from "../../../services/material-type.service";


@Component({
  selector: 'app-add-material-type',
  templateUrl: './add-material-type.component.html',
  styleUrls: ['./add-material-type.component.css']
})
export class AddMaterialTypeComponent {

  materialType: MaterialType = {
    id: 0,
    code: 0,
    description: ''
  }

  public constructor(private router: Router,
                     private materialTypeService: MaterialTypeService) {
  }

  public createMaterialType(): void {
    this.materialTypeService.addMaterialType(this.materialType).subscribe(() =>
      this.router.navigate(['/material-type']))
  }

}
