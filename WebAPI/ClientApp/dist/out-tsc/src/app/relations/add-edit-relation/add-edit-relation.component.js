import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
let AddEditRelationComponent = class AddEditRelationComponent {
    constructor(service) {
        this.service = service;
    }
    ngOnInit() {
        this.Id = this.relation.Id,
            this.Name = this.relation.Name,
            this.FullName = this.relation.FullName,
            this.TelephoneNumber = this.relation.TelephoneNumber,
            this.Email = this.relation.Email,
            this.Country = this.relation.Country,
            this.City = this.relation.City,
            this.Street = this.relation.Street,
            this.PostalCode = this.relation.PostalCode,
            this.StreetNumber = this.relation.StreetNumber;
    }
    addRelation() {
        var val = {
            Id: this.Id,
            Name: this.Name,
            FullName: this.FullName,
            TelephoneNumber: this.TelephoneNumber,
            Email: this.Email,
            Country: this.Country,
            City: this.City,
            Street: this.Street,
            PostalCode: this.PostalCode,
            StreetNumber: this.StreetNumber
        };
        this.service.addRelation(val).subscribe(res => {
            alert(res.toString());
        });
    }
    updateRelation() {
        var val = {
            Id: this.Id,
            Name: this.Name,
            FullName: this.FullName,
            TelephoneNumber: this.TelephoneNumber,
            Email: this.Email,
            Country: this.Country,
            City: this.City,
            Street: this.Street,
            PostalCode: this.PostalCode,
            StreetNumber: this.StreetNumber
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