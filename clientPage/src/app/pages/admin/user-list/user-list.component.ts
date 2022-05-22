import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/Model/interfaces/usuario';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'userName'];
  dataSource:Usuario[]=[];
  constructor(private userService:UserService,private router:Router) { }

  ngOnInit(): void {
    this.cargarUsuarios();
  }


  cargarUsuarios(){
    this.userService.getAllUsers().subscribe((data:Usuario[])=>{
      this.dataSource=data;
      console.log(data);
    })
  }

  selectUser(id:number){
    this.router.navigate([`/admin/admin-management/user-detail/${id}`])
  }

}
