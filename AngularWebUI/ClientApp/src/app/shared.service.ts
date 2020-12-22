import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpParams } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

  readonly ApiUrl: string = environment.apiHost;
  readonly RelationsApiAlias: string = "/relations";
  readonly CountriesApiAlias: string = "/countries";
  
  PageNumber: number = 1;
  PageSize: number = 5;
  SortBy: string = "Country";
  FilterBy: string = "None";
  OrderByDescending: boolean = false;

  QueryParams: HttpParams;

  DeleteIdList: [];

  RelationsUrlString: string = this.ApiUrl + this.RelationsApiAlias;
  CountriesUrlString: string = this.ApiUrl + this.CountriesApiAlias;

  constructor(private http: HttpClient, private toastrService: ToastrService,) { }

  getRelationsList(): Observable<any[]> {
    return this.http.get<any>(this.RelationsUrlString, {params: this.QueryParams});
  }

  getCountriesList(): Observable<any[]> {
    return this.http.get<any>(this.RelationsUrlString);
  }

  addRelation(val: object): Observable<any[]> {
    this.toastrService.success("Relation added successfully!");
    return this.http.post<any>(this.RelationsUrlString, val);
  }

  updateRelation(id: string, val: object): Observable<any[]>{
    this.toastrService.success("Relation updated");
    return this.http.put<any>(this.RelationsUrlString + "/" + id, val);
  }

  sortRelationsList(sortBy: string): Observable<any[]> {
    this.SortBy = sortBy;
    this.OrderByDescending = !this.OrderByDescending;

    this.QueryParams = new HttpParams().set("SortBy",sortBy).set("OrderByDescending", this.OrderByDescending.toString()); //Create new HttpParams

    return this.http.get<any>(this.RelationsUrlString + "?",  {params: this.QueryParams});
  }

  changePage(pageNumber: number, pageSize: number): Observable<any[]> {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;

    this.QueryParams = new HttpParams().set("PageNumber",pageNumber.toString()).set("PageSize", pageSize.toString()); //Create new HttpParams
    return this.http.get<any>(this.RelationsUrlString + "?",  {params: this.QueryParams});
  }

  deleteRelation(id: string){
    return this.http.delete(this.RelationsUrlString + "?ids=" + id);
  }

}
