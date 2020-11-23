import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

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
      RelationName:""
    }
    this.ModalTitle= "Add relation";
    this.ActivateAddEditRelationsComponent= true;
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

  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      this.RelationsList = data;
    });
  }

}
