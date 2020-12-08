import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRelationComponent } from './add-edit-relation.component';

describe('AddEditRelationComponent', () => {
  let component: AddEditRelationComponent;
  let fixture: ComponentFixture<AddEditRelationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditRelationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditRelationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
