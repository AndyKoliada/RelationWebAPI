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
  Email: string;
  Country: string;
  City: string;
  Street: string;
  PostalCode: string;
  StreetNumber: string;
  IsDisabled: boolean;

  ngOnInit(): void {

    this.Id = this.relation.Id,
    this.Name = this.relation.Name,
    this.FullName = this.relation.FullName,
    this.TelephoneNumber = this.relation.TelephoneNumber,
    this.Email = this.relation.Email,
    this.Country = this.relation.Country,
    this.City = this.relation.City,
    this.Street = this.relation.Street,
    this.PostalCode = this.relation.PostalCode,
    this.StreetNumber = this.relation.StreetNumber
  }


  addRelation() {
    var val = {
      Name:this.Name,
      FullName:this.FullName,
      TelephoneNumber:this.TelephoneNumber,
      Email:this.Email,
      Country:this.Country,
      City:this.City,
      Street:this.Street,
      PostalCode:this.PostalCode,
      StreetNumber:this.StreetNumber
    };
    this.service.addRelation(val).subscribe(res=>{
      alert(res.toString())
    });
  }

  updateRelation() { 
    var val = {
      Id:this.Id,
      Name:this.Name,
      FullName:this.FullName,
      TelephoneNumber:this.TelephoneNumber,
      Email:this.Email,
      Country:this.Country,
      City:this.City,
      Street:this.Street,
      PostalCode:this.PostalCode,
      StreetNumber:this.StreetNumber
    };
    this.service.updateRelation(val).subscribe(res=>{
      alert(res.toString())
    });
  }
}
