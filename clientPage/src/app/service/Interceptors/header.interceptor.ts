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
  export class HeaderInterceptor implements HttpInterceptor {
    constructor(
      private localStorage: LocalStorageService,
      private loaderService: SpinnerService
    ) {}
  
    intercept(
      request: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
      this.loaderService.show();
      //console.log('spinner');
      const authToken = this.localStorage.getItem('accessToken');
      const authRequest = !!authToken
        ? request.clone({
            setHeaders: { Authorization: 'Bearer' + ' ' + authToken },
          })
        : request;
  
      return next.handle(authRequest).pipe(
        finalize(() => this.loaderService.hide())
        //finalize(() => console.log('end spinner'))
      );
    }
  }
  