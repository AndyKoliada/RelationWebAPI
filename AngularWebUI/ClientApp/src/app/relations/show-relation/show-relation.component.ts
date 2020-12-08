import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { AddEditRelationComponent } from '../add-edit-relation/add-edit-relation.component';
import { RelationsComponent } from '../relations.component';

@Component({
  selector: 'app-show-relation',
  templateUrl: './show-relation.component.html',
  styleUrls: ['./show-relation.component.css']
})

export class ShowRelationComponent implements OnInit {

  RelationsList: any = [];

  
  constructor(private service: SharedService) {}

  ModalTitle: string;
  ActivateAddEditRelationsComponent: boolean = false;
  relation: any;

  ngOnInit(): void {
    this.refreshRelationsList();
  }

  addClick() {
    this.relation = {
      Id: null,
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
    if(confirm('Are you sure?'))
    { 
        this.service.deleteRelation(item.Id).subscribe(data=>{
          this.refreshRelationsList();
        })
      }
  }

  sortClick(param: string) {
    this.service.sortRelationsList(param);
    this.refreshRelationsList();
  }

  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      this.RelationsList = data;
    });
  }

}
