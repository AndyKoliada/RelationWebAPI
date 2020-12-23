import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { RelationsComponent } from './relations/relations.component';
import { ShowRelationComponent } from './relations/show-relation/show-relation.component';
import { AddEditRelationComponent } from './relations/add-edit-relation/add-edit-relation.component';
import { SharedService } from './shared.service';
import { UrlString } from './models/UrlString';
import { Pagination } from './models/Pagination';
import { PaginationComponent } from './pagination/pagination.component';


@NgModule({
  declarations: [
    AppComponent,
    RelationsComponent,
    ShowRelationComponent,
    AddEditRelationComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([{ path: '', component: RelationsComponent }]),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],

  providers: [SharedService, UrlString, Pagination],
  bootstrap: [AppComponent]
})
export class AppModule { }
