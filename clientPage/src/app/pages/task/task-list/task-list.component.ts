import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TaskupdateDialogComponent } from 'src/app/components/taskupdate-dialog/taskupdate-dialog.component';
import { TaskModel } from 'src/app/Model/interfaces/TaskModel';
import { AuthService } from 'src/app/service/auth.service';
import { TaskService } from 'src/app/service/task.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit,OnDestroy {
 private unsubscribe$ = new Subject();
  constructor(private taskService:TaskService,
    private auth:AuthService,
    private matdialog:MatDialog
    ) { }
  tareas:TaskModel[]=[];
  row:number=1;
  

  ngOnInit(): void {
    this.setRow(window.innerWidth);
    this.cargarTareas();
    
  }

  cargarTareas()
  {
    let id = this.auth.getUserId();
    this.taskService.getAll(id).pipe(takeUntil(this.unsubscribe$))
    .subscribe((datos:TaskModel[])=>{
      this.tareas = datos;
      console.log(this.tareas)
    })
  }
  setRow(ancho:any){
    let width=0;
    if(!isNaN(ancho)){
      width=ancho;
    }else{
      width=ancho.target.innerWidth;
    }
    
    if(width<=576){
      this.row=1;
    }else if(width>576 && width<768){
      this.row=2;
    }else if(width>=768 && width<992){
      this.row=3;
    }else if(width>=992 && width<1200){
      this.row=3;
    }else{
      this.row=3
    }
  }


  ngOnDestroy(): void {
    this.unsubscribe$.next(true);
    this.unsubscribe$.complete();
  }

  updatDialoge(id:number,msn:string){
    this.matdialog
    .open(TaskupdateDialogComponent, {
      height: '290px',
      width: '450px',
      data:{id,msn}
    })
    .afterClosed()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(() => {
     console.log('Se cerro');
     this.cargarTareas();
    });
  }
}
