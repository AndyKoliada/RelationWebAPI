import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RelationsComponent } from './relations/relations.component';
import { ShowRelationComponent } from './relations/show-relation/show-relation.component';
import { AddEditRelationComponent } from './relations/add-edit-relation/add-edit-relation.component';
import { SharedService } from './shared.service';


@NgModule({
  declarations: [
    AppComponent,
    ShowRelationComponent,
    RelationsComponent,
    AddEditRelationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([{ path: '', component: RelationsComponent }]),
    FormsModule,
    ReactiveFormsModule
  ],

  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
