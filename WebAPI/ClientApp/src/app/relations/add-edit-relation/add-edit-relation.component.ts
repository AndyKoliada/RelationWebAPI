import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-edit-relation',
  templateUrl: './add-edit-relation.component.html',
  styleUrls: ['./add-edit-relation.component.css']
})
export class AddEditRelationComponent implements OnInit {

  constructor() {}

  @Input() relation: any;
  RelationName: string;

  ngOnInit(): void {

    this.RelationName = this.relation.RelationName;
  }

}
