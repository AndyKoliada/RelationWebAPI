import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html',
  styleUrls: ['./add-edit-relation.component.css']
})


export class AddEditRelationComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() relation: any;
  Id: string;
  Name: string;
  FullName: string;
  TelephoneNumber: string;
  EmailAddress: string;
  DefaultCountry: string;
  DefaultCity: string;
  DefaultStreet: string;
  DefaultPostalCode: string;
  StreetNumber: string;
  IsDisabled: boolean;

  ngOnInit(): void {
    this.Id = this.relation.Id,
    this.Name = this.relation.Name,
    this.FullName = this.relation.FullName,
    this.TelephoneNumber = this.relation.TelephoneNumber,
    this.EmailAddress = this.relation.EmailAddress,
    this.DefaultCountry = this.relation.DefaultCountry,
    this.DefaultCity = this.relation.DefaultCity,
    this.DefaultStreet = this.relation.DefaultStreet,
    this.DefaultPostalCode = this.relation.DefaultPostalCode,
    this.StreetNumber = this.relation.StreetNumber
  }


  addRelation() {
    var val = {
      Name:this.Name,
      FullName:this.FullName,
      TelephoneNumber:this.TelephoneNumber,
      EmailAddress:this.EmailAddress,
      DefaultCountry:this.DefaultCountry,
      DefaultCity:this.DefaultCity,
      DefaultStreet:this.DefaultStreet,
      DefaultPostalCode:this.DefaultPostalCode,
      StreetNumber:this.StreetNumber
    };
    this.service.addRelation(val).subscribe();
  }

  updateRelation() { 
    var val = {
      Id:this.Id,
      Name:this.Name,
      FullName:this.FullName,
      TelephoneNumber:this.TelephoneNumber,
      EmailAddress:this.EmailAddress,
      DefaultCountry:this.DefaultCountry,
      DefaultCity:this.DefaultCity,
      DefaultStreet:this.DefaultStreet,
      DefaultPostalCode:this.DefaultPostalCode,
      StreetNumber:this.StreetNumber
    };
    
    this.service.updateRelation(this.Id, val).subscribe();

    console.log(val);
  }
}
