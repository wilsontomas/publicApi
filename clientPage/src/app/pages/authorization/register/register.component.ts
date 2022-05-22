import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { JwtAuthResult } from 'src/app/Model/auth-result';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  private unsubscribe$=new Subject();
  constructor(
    private bd:FormBuilder,
    private auth:AuthService,
    private router:Router) { }

  registerForm:FormGroup=new FormGroup({});
  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(){
    this.registerForm = this.bd.group({
      userName:['',[Validators.required]],
      firstName:['',[Validators.required]],
      lastName:['',[Validators.required]],
      email:['',[Validators.required]],
      password:['',[Validators.required]],
     

      typeId:[1],
    })
  }
  register(){
    if(this.registerForm.valid){
    
     //console.log(this.registerForm.value)
      this.auth.register(this.registerForm.value).pipe(takeUntil(this.unsubscribe$))
      .subscribe((data:JwtAuthResult)=>{

            this.router.navigate(['account/account-service/home']);
      })
    }
  }




}
