import { Component, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { Usuario } from 'src/app/Model/interfaces/usuario';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  info:Usuario =new Usuario();
  private unsubscribe$=new Subject();
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getLoggedUserInfo();
  }

  getLoggedUserInfo(){
    this.userService.getUserInfo()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((data:Usuario)=>{
      this.info=data;
      console.log(data)
    })
  }

}
