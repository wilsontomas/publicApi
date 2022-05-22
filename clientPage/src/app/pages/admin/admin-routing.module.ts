import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from 'src/app/components/not-found/not-found.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'user-list',
    pathMatch:'full'
  },
  {
    path:'user-list'
  ,component:UserListComponent
  },
  {
    path:'create-user',
    component:CreateUserComponent
  },
  {
    path:'user-detail/:id',
    component:UserDetailComponent
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
export class AdminRoutingModule { }
