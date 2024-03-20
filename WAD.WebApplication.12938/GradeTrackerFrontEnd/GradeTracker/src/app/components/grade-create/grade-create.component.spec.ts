import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeCreateComponent } from './grade-create.component';

describe('GradeCreateComponent', () => {
  let component: GradeCreateComponent;
  let fixture: ComponentFixture<GradeCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GradeCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GradeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
