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
  RelationId: string;
  RelationName: string;

  ngOnInit(): void {

    this.RelationName = this.RelationName;
    this.RelationId = this.RelationId;
  }


  addRelation() {
    var val = {
      RelationId:this.RelationId,
      RelationName:this.RelationName,
/*       // CreatedAt, 
      // CreatedBy, 
      // IsDisabled, 
      // IsTemporary, 
      // IsMe, 
      // PaymentViaAutomaticDebit, 
      // InvoiceDateGenerationOptions, 
      // InvoiceGroupByOptions */
    };
    this.service.addRelation(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateRelation() { 
    var val = {
      RelationId:this.RelationId,
      RelationName:this.RelationName,
/*       // CreatedAt, 
      // CreatedBy, 
      // IsDisabled, 
      // IsTemporary, 
      // IsMe, 
      // PaymentViaAutomaticDebit, 
      // InvoiceDateGenerationOptions, 
      // InvoiceGroupByOptions */
    };
    this.service.updateRelation(val).subscribe(res=>{
      alert(res.toString());
    });
  }
}
