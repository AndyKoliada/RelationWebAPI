/* import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly ApiUrl: string = environment.apiHost;
  readonly ApiAlias: string = "/relations";
  PageNumber: number = 1;
  PageSize: number = 5;
  SortBy: string = "Country";
  FilterBy: string = "None";
  DeleteIdList: [];
  OrderByDescending: boolean = false;

  QueryString: string = this.ApiUrl + this.ApiAlias + "/" + this.PageNumber + "/" + this.PageSize
    + "/" + this.SortBy + "/" + this.OrderByDescending + "/" + this.FilterBy;

  constructor(private http: HttpClient) { }

  getRelationsList(): Observable<any[]> {
    return this.http.get<any>(this.QueryString);
  }

  addRelation(val: object) {
    return this.http.post(this.ApiUrl + this.ApiAlias, val);
  }

  updateRelation(id: string, val: object) {
    return this.http.put(this.ApiUrl + this.ApiAlias + "/" + id, val);
  }

  sortRelationsList(sortBy: string): Observable<any[]> {
    this.OrderByDescending = !this.OrderByDescending;
    this.SortBy = sortBy;
    this.QueryString = this.ApiUrl + this.ApiAlias + "/" + this.PageNumber + "/" + this.PageSize
      + "/" + this.SortBy + "/" + this.OrderByDescending + "/" + this.FilterBy;
    return this.http.get<any>(this.QueryString);
  }

  changePage(pageNumber: number, pageSize: number): Observable<any[]> {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;
    this.QueryString = this.ApiUrl + this.ApiAlias + "/" + this.PageNumber + "/" + this.PageSize
      + "/" + this.SortBy + "/" + this.OrderByDescending + "/" + this.FilterBy;
    return this.http.get<any>(this.QueryString);
  }

  deleteRelation(id: string) {
    return this.http.delete(this.ApiUrl + this.ApiAlias + "/" + id);
  }

}
 */