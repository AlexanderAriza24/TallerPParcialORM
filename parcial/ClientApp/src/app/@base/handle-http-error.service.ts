import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable, of } from 'rxjs';
import { AlertModalComponent } from './alert-modal/alert-modal.component';

@Injectable({
  providedIn: 'root'
})
export class HandleHttpErrorService {

  constructor(private modalService : NgbModal) { }

  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Error";
      messageBox.componentInstance.message = error;

      return of(result as T);
    };
  }
  public log(message: string) {
    console.log(message);
  }
}
