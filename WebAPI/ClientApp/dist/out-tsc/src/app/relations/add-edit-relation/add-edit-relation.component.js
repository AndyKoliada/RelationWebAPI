import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
let AddEditRelationComponent = class AddEditRelationComponent {
    constructor(service) {
        this.service = service;
    }
    ngOnInit() {
        this.Id = this.relation.id,
            this.Name = this.relation.Name,
            this.FullName = this.relation.FullName,
            this.TelephoneNumber = this.relation.TelephoneNumber,
            this.EMailAddress = this.relation.EMailAddress,
            this.DefaultCountry = this.relation.DefaultCountry,
            this.DefaultCity = this.relation.DefaultCity,
            this.DefaultStreet = this.relation.DefaultStreet,
            this.DefaultPostalCode = this.relation.DefaultPostalCode,
            this.StreetNumber = this.relation.StreetNumber;
    }
    addRelation() {
        var val = {
            Name: this.Name,
            FullName: this.FullName,
            TelephoneNumber: this.TelephoneNumber,
            EMailAddress: this.EMailAddress,
            DefaultCountry: this.DefaultCountry,
            DefaultCity: this.DefaultCity,
            DefaultStreet: this.DefaultStreet,
            DefaultPostalCode: this.DefaultPostalCode,
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
            EMailAddress: this.EMailAddress,
            DefaultCountry: this.DefaultCountry,
            DefaultCity: this.DefaultCity,
            DefaultStreet: this.DefaultStreet,
            DefaultPostalCode: this.DefaultPostalCode,
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