import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError  } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Ayuda } from '../Apoyos/models/ayuda';

@Injectable({
  providedIn: 'root'
})
export class AyudaService {

  baseUrl: string;
  constructor(
  private http: HttpClient,
  @Inject('BASE_URL') baseUrl: string,
  private handleErrorService: HandleHttpErrorService) 
  { 
    this.baseUrl = baseUrl;
  }

  get(): Observable<Ayuda[]> {
    return this.http.get<Ayuda[]>(this.baseUrl + 'api/Ayuda')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Ayuda[]>('Consulta Ayuda', null))
        );
  }

  post(ayuda: Ayuda): Observable<Ayuda> {
    return this.http.post<Ayuda>(this.baseUrl + 'api/Ayuda', ayuda)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Ayuda>('Registrar Ayuda', null))
        );
  }

  verificarAyuda(ayuda: Ayuda): Observable<Boolean> {
    return this.http.get<Boolean>(this.baseUrl + 'api/Ayuda/'+ ayuda.valorAyuda)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Boolean>('Consulta Total', null))
        );
  }

  totalAyuda(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/Total')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<number>('Total Ayuda', null))
        );
  }
}
