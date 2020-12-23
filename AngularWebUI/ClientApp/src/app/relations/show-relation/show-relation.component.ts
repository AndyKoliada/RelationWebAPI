import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { Relation } from '../../models/Relation'

@Component({
  selector: 'app-show-relation',
  templateUrl: './show-relation.component.html'
})

export class ShowRelationComponent implements OnInit {

  constructor(private service: SharedService, private toastrService: ToastrService) { }

  RelationsList: Relation[];

  ModalTitle: string;
  ActivateAddEditRelationsComponent: boolean = false;
  relation: Relation;

  ngOnInit(): void {
    this.refreshRelationsList();
  }

  addClick() {
    this.relation = {
      Id: null
    }
    this.ModalTitle = "Add new relation";
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
    if (confirm('Are you sure?')) {
      this.service.deleteRelation(item.Id).subscribe(/* data => {
        this.relation = data
      } */)
      this.toastrService.success("Relation deleted");
    }
    this.refreshRelationsList();
  }

  sortClick(param: string) {
    this.service.sortRelationsList(param);
    this.refreshRelationsList();
  }
  
  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      this.RelationsList = data;
      //this.service.RelationsList = data;
    });
  }

}