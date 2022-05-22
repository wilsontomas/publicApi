import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskupdateDialogComponent } from './taskupdate-dialog.component';

describe('TaskupdateDialogComponent', () => {
  let component: TaskupdateDialogComponent;
  let fixture: ComponentFixture<TaskupdateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskupdateDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskupdateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
