import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { ShowRelationComponent } from './show-relation.component';
describe('ShowRelationComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [ShowRelationComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ShowRelationComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=show-relation.component.spec.js.map