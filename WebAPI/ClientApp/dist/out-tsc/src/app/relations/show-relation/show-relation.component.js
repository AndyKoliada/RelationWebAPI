import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ShowRelationComponent = class ShowRelationComponent {
    constructor(service) {
        this.service = service;
        this.RelationsList = [];
        this.ActivateAddEditRelationsComponent = false;
    }
    ngOnInit() {
        this.refreshRelationsList();
    }
    addClick() {
        this.relation = {
            //Id: 0,
            Name: ''
        };
        this.ModalTitle = "Add relation";
        this.ActivateAddEditRelationsComponent = true;
    }
    closeClick() {
        this.ActivateAddEditRelationsComponent = false;
        this.refreshRelationsList();
    }
    editClick(item) {
        this.relation = item;
        this.ModalTitle = "Edit relation";
        this.ActivateAddEditRelationsComponent = true;
    }
    deleteClick(item) {
        if (true) //confirm('Are you sure?')
         {
            this.service.deleteRelation(item.Id); //.subscribe(data=>{
            // alert(data.toString());
            //  });
            this.refreshRelationsList();
        }
        /*     this.relation = item;
            this.ModalTitle = "Delete relation";
            this.ActivateAddEditRelationsComponent = true; */
    }
    refreshRelationsList() {
        this.service.getRelationsList().subscribe(data => {
            this.RelationsList = data;
        });
    }
};
ShowRelationComponent = __decorate([
    Component({
        selector: 'app-show-relation',
        templateUrl: './show-relation.component.html',
        styleUrls: ['./show-relation.component.css']
    })
], ShowRelationComponent);
export { ShowRelationComponent };
//# sourceMappingURL=show-relation.component.js.map