import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/service/auth.service';
import { TaskService } from 'src/app/service/task.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit,OnDestroy {
  private unsubscribe$=new Subject();
  constructor(
    private bd:FormBuilder,
    private auth:AuthService,
    private router:Router,
    private taskService:TaskService) { }
  taskForm:FormGroup=new FormGroup({});
  ngOnInit(): void {
    this.buildForm();
  }
  buildForm(){
    this.taskForm = this.bd.group({
      name:['',[Validators.required]],
      message:['',[Validators.required]],
      usuarioId:[this.auth.getUserId()],
    })
  }

  guardar(){
    if(this.taskForm.valid){
      this.taskService.add(this.taskForm.value).pipe(takeUntil(this.unsubscribe$))
      .subscribe(()=>{
        this.router.navigate(['/task/task-service/task-list']);
      })
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next(true);
    this.unsubscribe$.complete();
  }
}
