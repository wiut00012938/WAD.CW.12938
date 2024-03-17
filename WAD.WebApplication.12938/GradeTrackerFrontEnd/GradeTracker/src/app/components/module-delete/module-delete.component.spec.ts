import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleDeleteComponent } from './module-delete.component';

describe('ModuleDeleteComponent', () => {
  let component: ModuleDeleteComponent;
  let fixture: ComponentFixture<ModuleDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModuleDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModuleDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
