import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import { SharedModule } from 'src/app/components/shared.module';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { AddTaskComponent } from './add-task/add-task.component';


@NgModule({
  declarations: [
    TaskListComponent,
    TaskDetailComponent,
    AddTaskComponent
  ],
  imports: [
    CommonModule,
    TaskRoutingModule,
    SharedModule
  ]
})
export class TaskModule { }
