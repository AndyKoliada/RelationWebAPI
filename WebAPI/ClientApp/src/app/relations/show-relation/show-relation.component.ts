import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { RelationsComponent } from '../relations.component';
//https://metanit.com/web/angular2/9.2.php
@Component({
  selector: 'app-show-relation',
  templateUrl: './show-relation.component.html',
  styleUrls: ['./show-relation.component.css']
})
export class ShowRelationComponent implements OnInit {

  constructor(private service: SharedService) { }

  RelationsList: any = [];

  ModalTitle: string;
  ActivateAddEditRelationsComponent: boolean = false;
  relation: any;

  ngOnInit(): void {
    this.refreshRelationsList();
  }

  addClick() {
    this.relation = {
      Id: 0,
      Name: ''
    }

    this.ModalTitle= "Add relation";
    this.ActivateAddEditRelationsComponent = true;
  }

  closeClick() {
    this.ActivateAddEditRelationsComponent = false;
    this.refreshRelationsList();
  }

  editClick(item) {
    this.relation = item;
    this.ModalTitle = "Edit relation";
    this.ActivateAddEditRelationsComponent = true;
  }

  deleteClick(item) {
    if(true) //confirm('Are you sure?')
    { 
      this.relation = item;
      this.service.deleteRelation(item.id).subscribe(data=>{
        alert(data.toString());
        
      });

    }
    
    this.ModalTitle = "Delete relation";
    //this.ActivateAddEditRelationsComponent = false;
  }

  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      this.RelationsList = data;
    });
  }

}
