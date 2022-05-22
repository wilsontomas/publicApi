import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { pipe, Subject, takeUntil } from 'rxjs';
import { TaskService } from 'src/app/service/task.service';
import { ToastService } from 'src/app/service/toast.service';
export interface dialogData{
  id:number;
  msn:string;
}
@Component({
  selector: 'app-taskupdate-dialog',
  templateUrl: './taskupdate-dialog.component.html',
  styleUrls: ['./taskupdate-dialog.component.css']
})
export class TaskupdateDialogComponent implements OnInit {
  private unsuscribe$ = new Subject();
  constructor(public dialogo: MatDialogRef<TaskupdateDialogComponent>,
    private taskService: TaskService,
    private toastCtrl: ToastService,
    @Inject(MAT_DIALOG_DATA) public data: dialogData
    ) { }

  ngOnInit(): void {
    console.log('se abrio el dialogo')
  }

  close(): void {
    this.dialogo.close(false);
  }

  update(){
    if(this.data.msn)
    {
      this.taskService.update(this.data.id,this.data.msn)
      .subscribe((data:any)=>{
        this.toastCtrl.presentToast("Se actualizo la tarea");
        this.close();
      });
    }else{
      this.toastCtrl.presentToast("Debe llenar la tarea");
    }
  }

}
