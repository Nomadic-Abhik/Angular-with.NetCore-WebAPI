import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListingComponent } from './listing/listing.component';
import { HttpClientModule } from '@angular/common/http';
import { CreationComponent } from './creation/creation.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MaterialModule} from '../app/material/material.module';
import { ConfirmComponent } from './shared/confirm/confirm.component';
import { ToastrModule } from 'ngx-toastr';
import {MessageService} from '../app/shared/message.service';

@NgModule({
  declarations: [
    AppComponent,
    ListingComponent,
    CreationComponent,
    ConfirmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    ToastrModule.forRoot()
  ],
  providers: [MessageService],
  bootstrap: [AppComponent],
  entryComponents : [CreationComponent,ConfirmComponent]
})
export class AppModule { }
