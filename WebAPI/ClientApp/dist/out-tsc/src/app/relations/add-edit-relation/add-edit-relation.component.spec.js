import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { AddEditRelationComponent } from './add-edit-relation.component';
describe('AddEditRelationComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [AddEditRelationComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(AddEditRelationComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=add-edit-relation.component.spec.js.map