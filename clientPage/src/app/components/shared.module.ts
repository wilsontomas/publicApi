import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//components
import { MaterialModule } from 'src/app/material/material/material.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UnauthorizeComponent } from './unauthorize/unauthorize.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { TaskupdateDialogComponent } from './taskupdate-dialog/taskupdate-dialog.component';


@NgModule({
  declarations: [
  
    NotFoundComponent,
    UnauthorizeComponent,
    TaskupdateDialogComponent
       
      
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
