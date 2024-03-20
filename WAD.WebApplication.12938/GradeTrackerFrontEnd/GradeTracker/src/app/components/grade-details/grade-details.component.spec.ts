import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeDetailsComponent } from './grade-details.component';

describe('GradeDetailsComponent', () => {
  let component: GradeDetailsComponent;
  let fixture: ComponentFixture<GradeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GradeDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GradeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
