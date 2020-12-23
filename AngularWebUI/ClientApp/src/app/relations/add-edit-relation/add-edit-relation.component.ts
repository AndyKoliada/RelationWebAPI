import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../../shared.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Relation } from '../../models/Relation'

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html'
})

export class AddEditRelationComponent implements OnInit {

  form: FormGroup;

  constructor(
    private service: SharedService,
    private formBuilder: FormBuilder
    ) { }

  @Input() 
  relation: Relation;
  Id: string;
  Name: string = "";
  FullName: string = "";
  TelephoneNumber: string = "";
  EmailAddress: string = "";
  Country: string = "";
  City: string = "";
  Street: string = "";
  PostalCode: string = "";
  StreetNumber: number;

  ngOnInit(): void {
    this.Id = this.relation.Id,
    this.Name = this.relation.Name,
    this.FullName = this.relation.FullName,
    this.TelephoneNumber = this.relation.TelephoneNumber,
    this.EmailAddress = this.relation.EmailAddress,
    this.Country = this.relation.Country,
    this.City = this.relation.City,
    this.Street = this.relation.Street,
    this.PostalCode = this.relation.PostalCode,
    this.StreetNumber = this.relation.StreetNumber

    this.form = this.formBuilder.group({
      Name: [this.relation.Name, [Validators.required, Validators.maxLength(50)]],
      EmailAddress: [this.relation.EmailAddress, [Validators.email, Validators.maxLength(50)]],
      TelephoneNumber: [this.relation.TelephoneNumber, [Validators.pattern("[0-9]{3}-[0-9]{3}-[0-9]{4}"), Validators.maxLength(50)]],
      FullName: [this.relation.FullName, [Validators.maxLength(50)]],
      Country: [this.relation.Country, [Validators.maxLength(50)]],
      City: [this.relation.City, [Validators.maxLength(50)]],
      Street: [this.relation.Street, [Validators.maxLength(50)]],
      PostalCode: [this.relation.PostalCode, [Validators.maxLength(10)]],
      StreetNumber: [this.relation.StreetNumber]
    });
    
  }

  addRelation(){
    return this.service.addRelation(this.form.value).subscribe();
  }

  updateRelation() {
    return this.service.updateRelation(this.relation.Id, this.form.value).subscribe();
  }

  onSubmit({ value, valid }) {
    this.service.getRelationsList();
  }

}
