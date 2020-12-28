import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SharedService } from '../../shared.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Relation } from '../../models/Relation'
import { ShowRelationComponent } from '../../relations/show-relation/show-relation.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html'
})

export class AddEditRelationComponent implements OnInit {

  constructor(
    private service: SharedService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private show: ShowRelationComponent
    ) { }

  form: FormGroup;
  
  countriesList: string[];

  @Input() relation: Relation;

  @Output() changesEvent = new EventEmitter<any>();

  ngOnInit(): void {

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

    this.getCountriesList();
  }

  addRelationClick(form: any){
      this.service.addRelation(form.value).subscribe(res=>{
      this.toastrService.success("Relation added successfully!");
      this.changesEvent.emit();
      this.show.refreshRelationsList();
    });
  }

  updateRelationClick(form: any) {
    this.service.updateRelation(this.relation.Id, form.value).subscribe(res => {
      this.toastrService.success("Relation updated");
      this.changesEvent.emit();
      this.show.refreshRelationsList();
      this.form.reset();
    });
  }

  getCountriesList() {
    this.service.getCountriesList().subscribe(countries => {
      this.countriesList = countries;
    });
  }

}
