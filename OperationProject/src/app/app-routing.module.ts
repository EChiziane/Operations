import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {MaterialTypeComponent} from "./Components/material-type/material-type.component";
import {MaterialComponent} from "./Components/material/material.component";
import {DestinationComponent} from "./Components/destination/destination.component";
import {ClientComponent} from "./Components/client/client.component";
import {DriverComponent} from "./Components/driver/driver.component";
import {CarLoadComponent} from "./Components/car-load/car-load.component";


const routes: Routes = [
  {path:'material-type',component:MaterialTypeComponent},
  {path:'material',component:MaterialComponent},
  {path:'destination',component:DestinationComponent},
  {path:'client',component:ClientComponent},
  {path:'driver',component:DriverComponent},
  {path:'carload', component:CarLoadComponent}
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
