import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Persona } from '../Apoyos/models/persona';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
    { 
      this.baseUrl = baseUrl;
    }

    get(): Observable<Persona[]> {
      return this.http.get<Persona[]>(this.baseUrl + 'api/Persona')
          .pipe(
              tap(_ => this.handleErrorService.log('datos enviados')),
              catchError(this.handleErrorService.handleError<Persona[]>('Consulta Persona', null))
          );
    }
  
    post(persona: Persona): Observable<Persona> {
      return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona)
          .pipe(
              tap(_ => this.handleErrorService.log('datos enviados')),
              catchError(this.handleErrorService.handleError<Persona>('Registrar Persona', null))
          );
    }

    verificarDuplicado(persona : Persona): Observable<Boolean> {
      return this.http.get<Boolean>(this.baseUrl + 'api/Persona/' + persona.identificacion)
          .pipe(
              tap(_ => this.handleErrorService.log('datos enviados')),
              catchError(this.handleErrorService.handleError<Boolean>('Verificar Persona', null))
          );
    }

  /*get(): Persona[]{
    return JSON.parse(localStorage.getItem('datos'));
  }

  post(persona: Persona){

    let personas: Persona[] = [];
    if(this.get() != null){
      personas = this.get();
    }
    personas.push(persona);
    localStorage.setItem('datos', JSON.stringify(personas));
  }

  verificarIdentificacion(persona: Persona): boolean{

    let personas: Persona[] = [];
    if(this.get() != null){
      personas = this.get();
    }
    for(let i of personas){
      
      if(i.identificacion == persona.identificacion){
        return true;
      }
    }
  }

  validarCampos(persona: Persona): boolean{

    if(persona.identificacion == null || persona.nombres == null || persona.apellidos == null || persona.edad == null || persona.sexo == null || persona.departamento == null || persona.ciudad == null || persona.valorApoyo == null || persona.modalidad == null || persona.fecha == null){
      return true;
    }else {
      return false;
    }
  }

  validarApoyoAsignado(persona: Persona): boolean{

    let valorApoyoAsignado = 0;
    let personas: Persona[] = [];
    if(this.get() != null){
      personas = this.get();
    }
    for(let i of personas){
      
      valorApoyoAsignado += i.valorApoyo;
    }
    if(persona.valorApoyo + valorApoyoAsignado > 600000000)
    return true;
  }

  totalApoyoAsignado(): number {

    let valorApoyoAsignado = 0;
    let personas: Persona[] = [];
    if(this.get() != null){
      personas = this.get();
    }
    for(let i of personas){
      
      valorApoyoAsignado += i.valorApoyo;
    }
    return valorApoyoAsignado;
  }*/
} 
