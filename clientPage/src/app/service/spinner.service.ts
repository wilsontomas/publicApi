import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  isLoading$: any = new Subject<boolean>();
  //isLoading: Boolean;
  constructor() {
    this.isLoading$.next(false);
    //this.isLoading = true;
  }

  hide(): void {
    this.isLoading$.next(false);
  }
  show(): void {
    this.isLoading$.next(true);
  }
}
