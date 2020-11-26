import {TemplateRef, ViewChild} from '@angular/core';
import {Component, OnInit} from '@angular/core';
import {Relation} from './relation';
import {RelationService} from './relation.service';
import {Observable} from 'rxjs';
   
@Component({ 
    selector: 'my-app', 
    templateUrl: './app.component.html',
    providers: [RelationService]
}) 
export class AppComponent implements OnInit {
    //типы шаблонов
    @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>;
       
    editedRelation: Relation;
    relations: Array<Relation>;
    isNewRecord: boolean;
    statusMessage: string;
       
    constructor(private serv: RelationService) {
        this.relations = new Array<Relation>();
    }
       
    ngOnInit() {
        this.loadRelations();
    }
       
    private loadRelations() {
        this.serv.getRelations().subscribe((data: Relation[]) => {
                this.relations = data; 
            });
    }

    addRelation() {
        this.editedRelation = new Relation();
        this.relations.push(this.editedRelation);
        this.isNewRecord = true;
    }
    
    editRelation(relation: Relation) {
        this.editedRelation = new Relation(relation.Id, relation.FullName, relation.TelephoneNumber, relation.EMailAddress, relation.DefaultCity,
            relation.DefaultCountry, relation.DefaultPostalCode, relation.DefaultStreet, relation.StreetNumber);
    }

    loadTemplate(relation: Relation) {
        if (this.editedRelation && this.editedRelation.Id === relation.Id) {
            return this.editTemplate;
        } else {
            return this.readOnlyTemplate;
        }
    }

    saveRelation() {
        if (this.isNewRecord) {

            this.serv.createRelation(this.editedRelation).subscribe(data => {
                this.statusMessage = 'Added successfully',
                this.loadRelations();
            });
            this.isNewRecord = false;
            this.editedRelation = null;
        } else {

            this.serv.updateRelation(this.editedRelation).subscribe(data => {
                this.statusMessage = 'Updated succesfully',
                this.loadRelations();
            });
            this.editedRelation = null;
        }
    }

    cancel() {

        if (this.isNewRecord) {
            this.relations.pop();
            this.isNewRecord = false;
        }
        this.editedRelation = null;
    }

    deleteRelation(relation: Relation) {
        this.serv.deleteRelation(relation.Id).subscribe(data => {
            this.statusMessage = 'Deleted succesfully',
            this.loadRelations();
        });
    }
}