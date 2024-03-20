import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignnmentGradesComponent } from './assignnment-grades.component';

describe('AssignnmentGradesComponent', () => {
  let component: AssignnmentGradesComponent;
  let fixture: ComponentFixture<AssignnmentGradesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignnmentGradesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssignnmentGradesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
