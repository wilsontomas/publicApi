import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
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
  constructor(private taskService:TaskService,private auth:AuthService) { }
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


}
