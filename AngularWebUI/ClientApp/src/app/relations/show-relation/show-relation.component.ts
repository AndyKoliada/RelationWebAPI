import { Component, OnInit} from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { Relation } from '../../models/Relation'

@Component({
  selector: 'app-show-relation',
  templateUrl: './show-relation.component.html',
})

export class ShowRelationComponent implements OnInit {

  RelationsList: Relation[];
  ModalTitle: string;
  ActivateAddEditRelationsComponent: boolean = false;
  relation: Relation;
  
  selectedRow: number;

  constructor(
    private service: SharedService,
    private toastrService: ToastrService
    ) { }

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
        if(res.status === 204) {
          this.toastrService.success("Relation deleted successfully", "Server responded");
        }
        else{
          this.toastrService.error("Relation is not deleted", "Something went wrong!");
        }
        this.refreshRelationsList();
      });
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