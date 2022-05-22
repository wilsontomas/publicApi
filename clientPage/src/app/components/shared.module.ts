import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//components
import { MaterialModule } from 'src/app/material/material/material.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UnauthorizeComponent } from './unauthorize/unauthorize.component';
import { SpinnerComponent } from './spinner/spinner.component';


@NgModule({
  declarations: [
  
    NotFoundComponent,
    UnauthorizeComponent,
    SpinnerComponent
       
      
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    MaterialModule,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class SharedModule { }
