import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
let AddEditRelationComponent = class AddEditRelationComponent {
    constructor(service) {
        this.service = service;
    }
    ngOnInit() {
        this.RelationName = this.RelationName;
        this.RelationId = this.RelationId;
    }
    addRelation() {
        var val = {
            RelationId: this.RelationId,
            RelationName: this.RelationName,
        };
        this.service.addRelation(val).subscribe(res => {
            alert(res.toString());
        });
    }
    updateRelation() {
        var val = {
            RelationId: this.RelationId,
            RelationName: this.RelationName,
        };
        this.service.updateRelation(val).subscribe(res => {
            alert(res.toString());
        });
    }
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