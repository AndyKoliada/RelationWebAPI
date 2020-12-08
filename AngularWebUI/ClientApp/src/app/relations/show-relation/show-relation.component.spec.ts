import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRelationComponent } from './show-relation.component';

describe('ShowRelationComponent', () => {
  let component: ShowRelationComponent;
  let fixture: ComponentFixture<ShowRelationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRelationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRelationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
