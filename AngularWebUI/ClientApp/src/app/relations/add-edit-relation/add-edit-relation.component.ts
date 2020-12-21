import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../../shared.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html',
  styleUrls: ['./add-edit-relation.component.css']
})

export class AddEditRelationComponent implements OnInit {

  form: FormGroup;

  constructor(
    private service: SharedService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder) { }

  @Input() relation: any;
  Id: string;
  Name: string;
  FullName: string;
  TelephoneNumber: string;
  EmailAddress: string;
  Country: string;
  City: string;
  Street: string;
  PostalCode: string;
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
      name: [this.relation.Name, Validators.required, Validators.maxLength(50)],
      email: [this.relation.EmailAddress, [Validators.email]],
      phone: [this.relation.TelephoneNumber, [Validators.pattern("[0-9]{3}-[0-9]{3}-[0-9]{4}")]],
      fullName: [this.relation.FullName],
      country: [this.relation.Country],
      city: [this.relation.City],
      street: [this.relation.Street],
      postalCode: [this.relation.PostalCode],
      streetNumber: [this.relation.StreetNumber],
    });
  }

  addRelation() {
    var val = {
      Name: this.Name,
      FullName: this.FullName,
      TelephoneNumber: this.TelephoneNumber,
      EmailAddress: this.EmailAddress,
      Country: this.Country,
      City: this.City,
      Street: this.Street,
      PostalCode: this.PostalCode,
      StreetNumber: this.StreetNumber
    };
    //this.service.addRelation(val).subscribe();
    this.service.addRelation(this.form.value).subscribe();
    this.toastrService.success("Relation added");
  }

  updateRelation() {
    var val = {
      Id: this.Id,
      Name: this.Name,
      FullName: this.FullName,
      TelephoneNumber: this.TelephoneNumber,
      EmailAddress: this.EmailAddress,
      Country: this.Country,
      City: this.City,
      Street: this.Street,
      PostalCode: this.PostalCode,
      StreetNumber: this.StreetNumber
    };
    this.service.updateRelation(this.Id, val).subscribe();

    this.toastrService.success("Relation updated");
  }

  onSubmit(customerData) {
    console.warn('Your order has been submitted', customerData);
  }

  nameIsRequiredWarning(){
    this.toastrService.warning("Name is required")
  }

  nameLengthWarning(){
    this.toastrService.warning("Name must be at least 3 characters long")
  }
}
