import { Component, OnInit } from '@angular/core';
import { AyudaService } from 'src/app/services/ayuda.service';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {

  personas: Persona[];
  searchText: string;
  totalApoyo: number;
  constructor(private personaService: PersonaService, private ayudaService: AyudaService) { }

  ngOnInit() {

    this.personaService.get().subscribe(result => {
      this.personas = result;
    });
    this.ayudaService.totalAyuda().subscribe(r => {
      this.totalApoyo = r;
    });
  }

  /*get(){
    this.personas = this.personaService.get();
    document.getElementsByName("totalApoyo")[0].value = this.personaService.totalApoyoAsignado();
  }*/

}
