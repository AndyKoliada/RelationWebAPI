import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
let AddEditRelationComponent = class AddEditRelationComponent {
    constructor(service) {
        this.service = service;
    }
    ngOnInit() {
        this.RelationName = this.relation.RelationName;
    }
    //1:07:24
    addRelaion() {
    }
    updateRelation() { }
};
__decorate([
    Input()
], AddEditRelationComponent.prototype, "relation", void 0);
AddEditRelationComponent = __decorate([
    Component({
        selector: 'app-add-edit-relation',
        templateUrl: './add-edit-relation.component.html',
        styleUrls: ['./add-edit-relation.component.css']
    })
], AddEditRelationComponent);
export { AddEditRelationComponent };
//# sourceMappingURL=add-edit-relation.component.js.map