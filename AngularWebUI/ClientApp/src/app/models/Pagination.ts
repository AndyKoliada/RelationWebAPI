import { HttpParams } from '@angular/common/http';

export class Pagination {
    PageNumber: number = 1;
    PageSize: number = 5;
    SortBy: string = "Country";
    FilterBy: string = "None";
    OrderByDescending: boolean = false;

    QueryParams: HttpParams = new HttpParams()
    .set("PageNumber", this.PageNumber.toString())
    .set("PageSize", this.PageSize.toString())
    .set("SortBy",this.SortBy)
    .set("FilterBy",this.FilterBy)
    .set("OrderByDescending", this.OrderByDescending.toString());
}