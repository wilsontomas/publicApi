import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class LocalStorageService {
  constructor(@Inject(PLATFORM_ID) private platformId: any) {}

  public setItem(key: string, value: string): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(key, value);
    }
  }

  public getItem(key: string): string |null  {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem(key);
    }
    return '';
  }

  public hasKey(key: string): boolean {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem(key) !== null;
    }
    return false;
  }

  public removeItem(key: string): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem(key);
    }
  }
}
