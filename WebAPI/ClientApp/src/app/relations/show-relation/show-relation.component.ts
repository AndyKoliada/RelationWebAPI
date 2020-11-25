import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { v4 as uuidv4 } from 'uuid';

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
      Name: ""
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
        alert(data.toString());
        this.refreshRelationsList();
      });

    }
/*     this.relation = item;
    this.ModalTitle = "Delete relation";
    this.ActivateAddEditRelationsComponent = true; */
  }

  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      /* console.log(data); */
      this.RelationsList = data;
    });
  }

}
