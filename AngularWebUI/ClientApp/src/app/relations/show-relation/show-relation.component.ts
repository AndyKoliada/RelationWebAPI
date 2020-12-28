import { Component, OnInit, ElementRef } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { Relation } from '../../models/Relation'

@Component({
  selector: 'app-show-relation',
  templateUrl: './show-relation.component.html',
 /*  styles: ['.table tr.active td { background-color:#123456 !important; color: white; }'] */
})

export class ShowRelationComponent implements OnInit {

  RelationsList: Relation[];
  ModalTitle: string;
  ActivateAddEditRelationsComponent: boolean = false;
  relation: Relation;
  
  selectedRow: number;

  constructor(
    private service: SharedService,
    private toastrService: ToastrService,
    private elRef: ElementRef
    ) { 
      this.setClickedRow = function(index){
        this.selectedRow = index;
      }
    }

  ngOnInit(): void {
    this.refreshRelationsList();
  }

  addClick() {
    this.relation = new Relation();
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

  setClickedRow(index){
    this.selectedRow = index;
  }
  
  deleteClick(item) {
    if (confirm('Are you sure?')) {
      this.service.deleteRelation(item.Id).subscribe(res => {
        this.toastrService.success("Relation deleted");
        this.refreshRelationsList();
      });
    }
  }

  sortClick(param: string) {
    this.service.sortRelationsList(param);
    this.refreshRelationsList();
  }

  reactOnModalEvent(formvalue: any) {
    this.refreshRelationsList();
  }
  
  refreshRelationsList() {
    this.service.getRelationsList().subscribe(data => {
      this.RelationsList = data;
    });
  }

}