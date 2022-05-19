import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  constructor(public toastController: MatSnackBar) {}

  presentToast(message: string, duration: number = 5000) {
    this.toastController.open(message, 'Cerrar', {
      duration: duration,
    });
  }
}
