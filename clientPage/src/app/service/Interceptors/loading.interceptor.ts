import {
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
  } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  
  import { Observable } from 'rxjs';
  import { finalize } from 'rxjs/operators';
import { LocalStorageService } from '../local-storage.service';
import { SpinnerService } from '../spinner.service';
  //import { LoadingService } from './loading.service';
  
  @Injectable()
  export class LoadingInterceptor implements HttpInterceptor {
    constructor(
      private loader: SpinnerService,
     
    ) {}
  
    intercept(
      request: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
      
      this.loader.show();
        console.log('mostrar')
      
  
      return next.handle(request).pipe(
        finalize(() => this.loader.hide())
        
      );
    }
  }