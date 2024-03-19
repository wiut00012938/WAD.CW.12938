import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleDeletestudentComponent } from './module-deletestudent.component';

describe('ModuleDeletestudentComponent', () => {
  let component: ModuleDeletestudentComponent;
  let fixture: ComponentFixture<ModuleDeletestudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModuleDeletestudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModuleDeletestudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
