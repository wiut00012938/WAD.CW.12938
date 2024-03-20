import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignmentCreateComponent } from './assignment-create.component';

describe('AssignmentCreateComponent', () => {
  let component: AssignmentCreateComponent;
  let fixture: ComponentFixture<AssignmentCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignmentCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssignmentCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
