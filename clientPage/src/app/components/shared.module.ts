import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//components
import { MaterialModule } from 'src/app/material/material/material.module';
import { NotFoundComponent } from './not-found/not-found.component';


@NgModule({
  declarations: [
  
    NotFoundComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class SharedModule { }
