import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RelationsComponent } from './relations/relations.component';
import { ShowRelationComponent } from './relations/show-relation/show-relation.component';
import { AddEditRelationComponent } from './relations/add-edit-relation/add-edit-relation.component';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            RelationsComponent,
            ShowRelationComponent,
            AddEditRelationComponent
        ],
        imports: [
            BrowserModule,
            HttpClientModule,
            FormsModule,
            ReactiveFormsModule,
            RouterModule.forRoot([{ path: 'relations', component: RelationsComponent }])
        ],
        providers: [SharedService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map