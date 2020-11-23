import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly ApiUrl = "https://localhost:44358/api";

  constructor(private http: HttpClient) { }

  getRelationsList(): Observable<any[]>{
    var result = this.http.get<any[]>(this.ApiUrl + '/relations');
    debugger;
    return result;
  }

  addRelation(val: any) {
    return this.http.post(this.ApiUrl + '/relations', val);
  }

  updateRelation(val: any) {
    return this.http.put(this.ApiUrl + '/relations', val);
  }

  deleteRelation(val: any) {
    return this.http.delete(this.ApiUrl + '/relations', val);
  }

  getAllRelationsNames(): Observable<any[]> {
    return this.http.get<any[]>(this.ApiUrl + '/relations');
  }

}
