import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';
import { SidenavAutosizeExample } from './sidenav/sidenav-autosize-example.component';
import { SidenavAutosizeExampleComponent } from './sidenav-autosize-example/sidenav-autosize-example.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from "@angular/material/list";
import {MatMenuModule} from "@angular/material/menu";
import {MatExpansionModule} from "@angular/material/expansion";
import {RouterOutlet} from "@angular/router";
import { MaterialTypeComponent } from './Components/material-type/material-type.component';
import { MaterialComponent } from './Components/material/material.component';
import {HttpClientModule} from "@angular/common/http";
import { DestinationComponent } from './Components/destination/destination.component';



@NgModule({
  declarations: [
    AppComponent,
    SidenavAutosizeExample,
    SidenavAutosizeExampleComponent,
    MaterialTypeComponent,
    MaterialComponent,
    DestinationComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatExpansionModule,
    RouterOutlet,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
