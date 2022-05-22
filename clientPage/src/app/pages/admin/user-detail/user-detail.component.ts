import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from 'src/app/Model/interfaces/usuario';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  constructor(private route: ActivatedRoute,private userService:UserService) { }

  userId:string|null='';
  id:number=0;
  info:Usuario = new Usuario();
  ngOnInit(): void {
    this.userId=this.route.snapshot.paramMap.get('id'); 
    this.getUserDetails();
  }
  
  getUserDetails(){
    if(this.userId!==null){
      this.id = parseInt(this.userId);
    }

    this.userService.getUserInfoById(this.id)
    .subscribe((user:Usuario)=>{
      this.info = user;
      console.log(user);
    });
  } 
}
