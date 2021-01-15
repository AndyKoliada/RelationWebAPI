import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { Pagination } from '../app/models/Pagination';
import { UrlString } from '../app/models/UrlString';
import { Relation } from '../app/models/Relation';
import { timeout, catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

  constructor(
    private http: HttpClient,
    private url: UrlString,
    public page: Pagination,
    public toastrService: ToastrService
  ) { }

  QueryParams: HttpParams = this.page.QueryParams;

  RelationsList: Relation[];

  getRelationsList(): Observable<Relation[]> {
    return this.http.get<Relation[]>(this.url.RelationsUrlString, { params: this.QueryParams });
  }

  refreshRelationsList(): Observable<Relation[]> {
    return this.getRelationsList();
  }

  getCountriesList(): Observable<string[]> {
    return this.http.get<string[]>(this.url.CountriesUrlString);
  }

  addRelation(val: object): Observable<Relation> {
    return this.http.post<Relation>(this.url.RelationsUrlString, val);
  }

  updateRelation(id: string, val: object): Observable<Relation> {
    return this.http.put<Relation>(this.url.RelationsUrlString + "/" + id, val);
  }

  sortRelationsList(sortBy: string): Observable<Relation[]> {
    this.page.SortBy = sortBy;
    this.page.OrderByDescending = !this.page.OrderByDescending;

    this.QueryParams = new HttpParams().append("SortBy", sortBy).append("OrderByDescending", this.page.OrderByDescending.toString()); //Create new HttpParams

    return this.http.get<Relation[]>(this.url.RelationsUrlString + "?", { params: this.QueryParams });
  }

  changePage(pageNumber: number, pageSize: number): Observable<Relation[]> {
    this.page.PageNumber = pageNumber;
    this.page.PageSize = pageSize;

    this.QueryParams = new HttpParams().set("PageNumber", pageNumber.toString()).set("PageSize", pageSize.toString()); //Create new HttpParams

    return this.http.get<Relation[]>(this.url.RelationsUrlString + "?", { params: this.QueryParams });
  }

  deleteRelation(id: string): Observable<any> {
    return this.http.delete(this.url.RelationsUrlString + "?ids=" + id, { observe: 'response' })
      .pipe(timeout(1000), catchError(this.handleError));
  }

  handleError(error) {
    this.toastrService.error("Relation is not deleted", "Something went wrong!");
    return error;
  }
}
