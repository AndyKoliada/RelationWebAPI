import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Relation} from './relation';
    
@Injectable()
export class RelationService{
    
    private url = "https://localhost:44358/api/relations";
    constructor(private http: HttpClient){ }
       
    getRelations(){
        return this.http.get(this.url);
    }
   
    createRelation(relation: Relation){
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
        return this.http.post(this.url, JSON.stringify(relation), {headers: myHeaders}); 
    }
    updateRelation(relation: Relation) {
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
        return this.http.put(this.url, JSON.stringify(relation), {headers:myHeaders});
    }
    deleteRelation(id: string){
        return this.http.delete(this.url + '/' + id);
    }
}