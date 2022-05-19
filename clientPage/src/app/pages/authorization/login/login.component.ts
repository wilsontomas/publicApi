import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { JwtAuthResult } from 'src/app/Model/auth-result';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 
  private unsubscribe$=new Subject();
  constructor(
    private bd:FormBuilder,
    private auth:AuthService,
    private router:Router) { }
  loginForm:FormGroup=new FormGroup({});
  ngOnInit(): void {
    this.buildForm();
  }
  buildForm(){
    this.loginForm = this.bd.group({
      username:['',[Validators.required]],
      password:['',[Validators.required]],
    })
  }

  login(){
    if(this.loginForm.valid){
      let username = this.loginForm.controls['username'].value;
      let clave = this.loginForm.controls['password'].value;
      this.auth.login(username,clave).pipe(takeUntil(this.unsubscribe$))
      .subscribe((data:JwtAuthResult)=>{
        console.log(this.auth.getUserRole());
            this.router.navigate(['account/account-service/home']);
      },(error)=>{
        console.log(error)
      })
    }
  }
}
