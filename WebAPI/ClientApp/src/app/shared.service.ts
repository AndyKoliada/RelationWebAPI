import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly ApiUrl: string = "https://localhost:44358/api";
  readonly ApiAlias: string = "/relations";

  constructor(private http: HttpClient) { }

  getRelationsList(): Observable<any[]>{
    return this.http.get<any>(this.ApiUrl + this.ApiAlias);
  }

  addRelation(val: object) {
    return this.http.post(this.ApiUrl + this.ApiAlias, val);
  }

  updateRelation(id: string, val: object) {
    return this.http.put(this.ApiUrl + this.ApiAlias + "/" + id, val);
  }

  deleteRelation(id: string) {
    return this.http.delete(this.ApiUrl + this.ApiAlias + "/" + id);
  }

}
