import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Base64UrlService } from './base64url.service';
import { LocalStorageService } from './local-storage.service';
import jwt_decode from 'jwt-decode';
import {appsetting} from './appSettings'
import { JwtAuthResult } from '../Model/auth-result';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private TokenStorageKeyName: string = 'accessToken';
  private auth$: BehaviorSubject<JwtAuthResult | null> = new BehaviorSubject<JwtAuthResult | null>(null);
  private controllerUrl = `${appsetting.API_URL}/api`;

  constructor(
    private http: HttpClient,
    private localStorage: LocalStorageService,
    private base64url: Base64UrlService
  ) {}

  isAuthorized(grantedRole: Number): boolean {
    if (
      this.getUserRole().some((x) => x === grantedRole) 
    ) {
      return true;
    }
    return false;
  }

  isAuthenticated(): boolean {
    const storedToken = this.localStorage.getItem(this.TokenStorageKeyName);
    if( storedToken ===null) return false;
    //console.log(!this.isTokenExpired(storedToken));
    return !this.isTokenExpired(storedToken);
  }

 
  public getUserId(): number {
    let valor = JSON.parse(this.getKeyFromToken('nameid'));
    return valor;
  }

  public getUserRole(): Number[] {
    let valor = JSON.parse(this.getKeyFromToken('role'));
    //console.log(valor);
    return valor;
  }

 
  get userName(): string {
    return this.getKeyFromToken('unique_name');
  }

  private getKeyFromToken(key: string): string  {
    const storedToken = this.localStorage.getItem(this.TokenStorageKeyName);
    if(storedToken===null) return '';
    const tokenPayload = <any>jwt_decode(storedToken);

    return tokenPayload.hasOwnProperty(key) ? tokenPayload[key] : null;
  }

  private isTokenExpired(token: string, offsetSeconds?: number): boolean {
    if (!token || token === '') {
      return true;
    }
    const date = this.getTokenExpirationDate(token);
    offsetSeconds = offsetSeconds || 0;

    if (date === null) {
      return false;
    }

    return !(date.valueOf() > new Date().valueOf() + offsetSeconds * 1000);
  }

  private getTokenExpirationDate(token: string): Date | null {
    let decoded: any;
    decoded = <any>jwt_decode(token);

    if (!decoded || !decoded.hasOwnProperty('exp')) {
      return null;
    }

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);

    return date;
  }

  login(username: string, password: string): Observable<JwtAuthResult> {
    this.removeAuthToken();
    const params = { username, password };
    const userInfo = this.base64url.encode(JSON.stringify(params), 'utf8');
    const url = `${this.controllerUrl}/auth/login`;
    const headers = { Authentication: `${userInfo}` };

    return this.http.get<JwtAuthResult>(url, { headers }).pipe(
      map((authResult:any) => {
        this.localStorage.setItem(
          this.TokenStorageKeyName,
          authResult.accessToken
        );

        this.auth$.next(authResult);

        return authResult;
      })
    );
  }

  logOut(): any {
    this.removeAuthToken();
    this.auth$.next(null);
  }



  removeAuthToken(): void {
    this.localStorage.removeItem(this.TokenStorageKeyName);
  }
}
