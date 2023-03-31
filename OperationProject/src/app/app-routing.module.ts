import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {MaterialTypeComponent} from "./Components/material-type/material-type.component";
import {MaterialComponent} from "./Components/material/material.component";
import {DestinationComponent} from "./Components/destination/destination.component";


const routes: Routes = [
  {path:'material-type',component:MaterialTypeComponent},
  {path:'material',component:MaterialComponent},
  {path:'destination',component:DestinationComponent},
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
