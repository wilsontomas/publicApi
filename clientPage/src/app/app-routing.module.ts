import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav/main-nav.component';
import { AccountGuard } from './service/guards/account.guard';
import { AdminGuard } from './service/guards/admin.guard';
import { AuthGuard } from './service/guards/auth.guard';
import { TaskGuard } from './service/guards/task.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth/auth-service',
    pathMatch: 'full',
  },
  {
    path: 'auth',
    component: MainNavComponent,
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      {
        path: 'auth-service',
        loadChildren: () =>
          import('../app/pages/authorization/authorization.module').then(
            (x) => x.AuthorizationModule
          ),
      },
    ],
  },
  {
    path: 'admin',
    component: MainNavComponent,
    canActivate: [AdminGuard],
    canActivateChild: [AdminGuard],
    children: [
      {
        path: 'admin-management',
        loadChildren: () =>
          import('../app/pages/admin/admin.module').then(
            (x) => x.AdminModule
          ),
      },
    ],
  },
  {
    path: 'task',
    component: MainNavComponent,
    canActivate: [TaskGuard],
    canActivateChild: [TaskGuard],
    children: [
      {
        path: 'task-service',
        loadChildren: () =>
          import('../app/pages/task/task.module').then(
            (x) => x.TaskModule
          ),
      },
    ],
  },
  {
    path: 'account',
    component: MainNavComponent,
    canActivate: [AccountGuard],
    canActivateChild: [AccountGuard],
    children: [
      {
        path: 'account-service',
        loadChildren: () =>
          import('../app/pages/account/account.module').then(
            (x) => x.AccountModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
