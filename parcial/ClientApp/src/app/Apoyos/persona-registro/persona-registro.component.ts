import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  persona: Persona;
  constructor(private personaService: PersonaService) { }

  ngOnInit(){
    this.persona = new Persona();
  }

  add() {
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert('Persona creada!');
        this.persona = p;
      }
    });
  }
  /*add(){
   
    if(this.personaService.validarCampos(this.persona)){

      alert('porfavor llene todos los campos');
    }else if(this.personaService.verificarIdentificacion(this.persona)){

      alert('la persona con la identificacion ' + this.persona.identificacion + ' ya esta registrada');
    }else if(this.personaService.validarApoyoAsignado(this.persona)){
      
      alert('el monto digitado excede el valor de ayuda disponible');
    }else {

      alert('se agrego una nueva persona' + JSON.stringify(this.persona));
      this.personaService.post(this.persona);
    }
  }*/
}
