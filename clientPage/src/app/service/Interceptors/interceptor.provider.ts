import { HTTP_INTERCEPTORS } from '@angular/common/http';

//import { HttpErrorHanddlerInterceptor } from './HttpErrorHanddlerInterceptor';
import { HeaderInterceptor } from './header.interceptor';
import { LoadingInterceptor } from './loading.interceptor';

// Aqui se declararrn la lista de interceptores para las peticiones
export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  
];