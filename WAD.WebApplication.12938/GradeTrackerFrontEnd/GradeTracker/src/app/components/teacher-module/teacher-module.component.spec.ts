import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherModuleComponent } from './teacher-module.component';

describe('TeacherModuleComponent', () => {
  let component: TeacherModuleComponent;
  let fixture: ComponentFixture<TeacherModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeacherModuleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TeacherModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
