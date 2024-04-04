import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompositorAddEditComponent } from './compositor-add-edit.component';

describe('CompositorAddEditComponent', () => {
  let component: CompositorAddEditComponent;
  let fixture: ComponentFixture<CompositorAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompositorAddEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompositorAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
