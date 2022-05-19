import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/service/auth.service';
import { Router } from '@angular/router';
import { MenuService } from 'src/app/service/menu.service';
import { IMenuItem } from 'src/app/Model/interfaces/ImenuItem';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
      menuList:IMenuItem[]=[];
  constructor(
    private breakpointObserver: BreakpointObserver,
    private auth:AuthService,
    private router:Router,
    private menu:MenuService
    ) {}
    ngOnInit(): void {
     this.fillMenu();
    }
  logout()
  {
    this.auth.logOut();
    this.router.navigate(['/auth/auth-service/login']);
  }
  fillMenu(){
    let rol = this.auth.getUserRole();
    this.menuList = this.menu.getAllLinks().filter(x=>x.rol===rol || x.rol===3)
  }
}
