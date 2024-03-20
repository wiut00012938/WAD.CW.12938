import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentModulesComponent } from './student-modules.component';

describe('StudentModulesComponent', () => {
  let component: StudentModulesComponent;
  let fixture: ComponentFixture<StudentModulesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentModulesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentModulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
