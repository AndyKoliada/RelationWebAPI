import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SharedService } from '../../shared.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Relation } from '../../models/Relation'
import { ShowRelationComponent } from '../show-relation/show-relation.component';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html'
})

export class AddEditRelationComponent implements OnInit {

  constructor(
    private service: SharedService,
    private formBuilder: FormBuilder,
    private show: ShowRelationComponent,
    private relations: Relation
    ) { }

  form: FormGroup;
  
  countriesList: string[];

  @Input() 
  relation: Relation;

  @Output() changesEvent = new EventEmitter<string>();

  ngOnInit(): void {

    this.getCountriesList();

    this.relations.Id = this.relation.Id,
    this.relations.Name = this.relation.Name,
    this.relations.FullName = this.relation.FullName,
    this.relations.TelephoneNumber = this.relation.TelephoneNumber,
    this.relations.EmailAddress = this.relation.EmailAddress,
    this.relations.Country = this.relation.Country,
    this.relations.City = this.relation.City,
    this.relations.Street = this.relation.Street,
    this.relations.PostalCode = this.relation.PostalCode,
    this.relations.StreetNumber = this.relation.StreetNumber

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

  addRelationClick(form: any){
    this.service.addRelation(form.value).subscribe();
    this.changesEvent.emit(form.value);
    this.show.refreshRelationsList();
  }

  updateRelationClick(form: any) {
    this.service.updateRelation(this.relation.Id, form.value).subscribe();
    this.changesEvent.emit(form.value);
    this.show.refreshRelationsList();
  }

  onSubmit(form: any) {
    this.show.refreshRelationsList();
    console.log("onSubmit act", form.value);//debug
  }

  getCountriesList() {
    this.service.getCountriesList().subscribe(countries => {
      this.countriesList = countries;
    });
  }

}
