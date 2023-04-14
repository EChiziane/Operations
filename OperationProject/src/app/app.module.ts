import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';
import {SidenavAutosizeExample} from './sidenav/sidenav-autosize-example.component';
import {SidenavAutosizeExampleComponent} from './sidenav-autosize-example/sidenav-autosize-example.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from "@angular/material/list";
import {MatMenuModule} from "@angular/material/menu";
import {MatExpansionModule} from "@angular/material/expansion";
import {RouterOutlet} from "@angular/router";
import {MaterialTypeComponent} from './Components/material-type/material-type.component';
import {MaterialComponent} from './Components/material/material.component';
import {HttpClientModule} from "@angular/common/http";
import {DestinationComponent} from './Components/destination/destination.component';
import {GridModule} from "@syncfusion/ej2-angular-grids";
import {MatTableModule} from "@angular/material/table";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";
import {ModalModule} from "ngx-bootstrap/modal";
import {TooltipModule} from "ngx-bootstrap/tooltip";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {AppRoutingModule} from "./app-routing.module";
import {MatPaginatorModule} from "@angular/material/paginator";
import { ClientComponent } from './Components/client/client.component';
import { DriverComponent } from './Components/driver/driver.component';
import { CarLoadComponent } from './Components/car-load/car-load.component';
import { AddClientComponent } from './Components/client/add-client/add-client.component';
import {MatCardModule} from "@angular/material/card";
import {FormsModule} from "@angular/forms";
import {AddDestinationComponent} from "./Components/destination/add-destination/add-destination.component";
import { AddDriverComponent } from './Components/driver/add-driver/add-driver.component';


@NgModule({
  declarations: [
    AppComponent,
    SidenavAutosizeExample,
    SidenavAutosizeExampleComponent,
    MaterialTypeComponent,
    MaterialComponent,
    DestinationComponent,
    ClientComponent,
    DriverComponent,
    CarLoadComponent,
    AddClientComponent,
 AddDestinationComponent,
 AddDriverComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatTableModule,
    MatExpansionModule,
    MatButtonModule,
    MatDialogModule,
    RouterOutlet,
    HttpClientModule,
    GridModule,
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    MatInputModule,
    MatSelectModule,
    AppRoutingModule,
    MatPaginatorModule,
    MatCardModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
