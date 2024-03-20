import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeDeleteComponent } from './grade-delete.component';

describe('GradeDeleteComponent', () => {
  let component: GradeDeleteComponent;
  let fixture: ComponentFixture<GradeDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GradeDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GradeDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
