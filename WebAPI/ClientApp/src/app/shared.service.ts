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
  return this.http.get<any>(this.ApiUrl + '/relation');
  }

  addRelation(val: any) {
    return this.http.post(this.ApiUrl + '/relation', val);
  }

  updateRelation(val: any) {
    return this.http.put(this.ApiUrl + '/relation', val);
  }

  deleteRelation(val: any) {
    return this.http.delete(this.ApiUrl + '/relation', val);
  }

  //getAllRelationsNames(): Observable<any[]> {
  //  return this.http.get<any[]>(this.ApiUrl + '/relation');
  //}

}
