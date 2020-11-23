import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../../shared.service';
//import { SharedService } from '/src/app/shared.service';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html',
  styleUrls: ['./add-edit-relation.component.css']
})
export class AddEditRelationComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() relation: any;
  RelationName: string;

  ngOnInit(): void {

    this.RelationName = this.relation.RelationName;
  }

  //1:07:24
  addRelaion() {
  }

  updateRelation() { }
}
