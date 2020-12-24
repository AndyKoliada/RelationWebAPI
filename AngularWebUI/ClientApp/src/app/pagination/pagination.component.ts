import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { SharedService } from '../shared.service';
import { Pagination } from '../models/Pagination';
import { FormsModule } from '@angular/forms';
import { ShowRelationComponent } from '../relations/show-relation/show-relation.component';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html'
})
export class PaginationComponent implements OnInit {

  constructor(
    private service: SharedService,
    private page: Pagination,
    private show: ShowRelationComponent
  ) { }

  @Input()
  PageNumber: number;
  PageSize: number;

  ngOnInit(): void {
    this.PageNumber = this.page.PageNumber;
    this.PageSize = this.page.PageSize;
  }

  nextPageClick() {
    this.service.changePage(this.page.PageNumber + 1, this.page.PageSize);
    this.show.refreshRelationsList();
  }

  previousPageClick() {
    if (this.page.PageNumber > 1) {
      this.service.changePage(this.page.PageNumber - 1, this.page.PageSize);
      this.show.refreshRelationsList();
    }
  }

}
