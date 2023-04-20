import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {MaterialTypeComponent} from "./Components/material-type/material-type.component";
import {MaterialComponent} from "./Components/material/material.component";
import {DestinationComponent} from "./Components/destination/destination.component";
import {ClientComponent} from "./Components/client/client.component";
import {DriverComponent} from "./Components/driver/driver.component";
import {CarLoadComponent} from "./Components/car-load/car-load.component";
import {AddClientComponent} from "./Components/client/add-client/add-client.component";
import {AddDestinationComponent} from "./Components/destination/add-destination/add-destination.component";
import {AddDriverComponent} from "./Components/driver/add-driver/add-driver.component";
import {AddMaterialComponent} from "./Components/material/add-material/add-material.component";
import {AddMaterialTypeComponent} from "./Components/material-type/add-material-type/add-material-type.component";
import {AddCarLoadComponent} from "./Components/car-load/add-car-load/add-car-load.component";


const routes: Routes = [
  {path: 'material-type', component: MaterialTypeComponent},
  {path: 'material', component: MaterialComponent},
  {path: 'destination', component: DestinationComponent},
  {path: 'client', component: ClientComponent},
  {path: 'driver', component: DriverComponent},
  {path: 'carload', component: CarLoadComponent},
  {path: 'client/add', component: AddClientComponent},
  {path: 'destination/add', component: AddDestinationComponent},
  {path: 'driver/add', component: AddDriverComponent},
  {path: 'material/add', component: AddMaterialComponent},
  {path: 'material-type/add', component: AddMaterialTypeComponent},
  {path: 'carload/add', component: AddCarLoadComponent},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
