import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from 'src/app/components/shared.module';
import { SpinnerComponent } from 'src/app/components/spinner/spinner.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    SpinnerComponent
  ], 
  imports: [ 
    CommonModule,
    AuthorizationRoutingModule,
    SharedModule
  ]
})
export class AuthorizationModule { }
