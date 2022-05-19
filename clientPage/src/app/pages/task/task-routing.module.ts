import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from 'src/app/components/not-found/not-found.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { TaskListComponent } from './task-list/task-list.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'task-list',
    pathMatch:'full'
  },
  {
    path:'task-list',
    component:TaskListComponent
  },
  {
    path:'add-task',
    component:AddTaskComponent
  },
  {
    path:'task-detail',
    component:TaskDetailComponent
  },
  {
    path:'**',
    component:NotFoundComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskRoutingModule { }
