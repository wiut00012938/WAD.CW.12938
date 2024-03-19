import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleAddstudentComponent } from './module-addstudent.component';

describe('ModuleAddstudentComponent', () => {
  let component: ModuleAddstudentComponent;
  let fixture: ComponentFixture<ModuleAddstudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModuleAddstudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModuleAddstudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
