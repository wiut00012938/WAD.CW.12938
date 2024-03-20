import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignmentDeleteComponent } from './assignment-delete.component';

describe('AssignmentDeleteComponent', () => {
  let component: AssignmentDeleteComponent;
  let fixture: ComponentFixture<AssignmentDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignmentDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssignmentDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
