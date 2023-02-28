import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {OperationTypeComponent} from './models/components/operation-type/operation-type.component';
import {UserComponent} from './models/components/user/user.component';
import {FormsModule} from "@angular/forms";
import {ModalModule} from "ngx-bootstrap/modal";
import {TitleComponent} from './models/components/title/title.component';
import {BilheteIdentidadeComponent} from './models/components/bilhete-identidade/bilhete-identidade.component';
import {OperationComponent} from './models/components/operation/operation.component';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import { MediaComponent } from './models/components/media/media.component';

@NgModule({
  declarations: [
    AppComponent,
    OperationTypeComponent,
    UserComponent,
    TitleComponent,
    BilheteIdentidadeComponent,
    OperationComponent,
    MediaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ModalModule.forRoot(),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
