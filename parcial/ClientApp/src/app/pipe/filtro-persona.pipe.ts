import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../Apoyos/models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(persona: Persona[], searchText: string): any {
    if (searchText == null) return persona;
   return persona.filter(p =>
   p.nombres.toLowerCase()
  .indexOf(searchText.toLowerCase()) !== -1);
    }

}
