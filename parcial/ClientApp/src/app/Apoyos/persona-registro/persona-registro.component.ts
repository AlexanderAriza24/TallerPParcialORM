import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { AyudaService } from 'src/app/services/ayuda.service';
import { PersonaService } from 'src/app/services/persona.service';
import { Ayuda } from '../models/ayuda';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  formGroupPersona: FormGroup;
  formGroupAyuda: FormGroup;
  persona: Persona;
  ayuda: Ayuda;
  constructor(
    private personaService: PersonaService, 
    private ayudaService : AyudaService, 
    private formBuilder : FormBuilder,
    private modalService : NgbModal) { }

  ngOnInit(){
    
    this.buildFormPersona();
    this.buildFormAyuda();
  }

  private buildFormPersona(){
    
    this.persona = new Persona();
    this.persona.identificacion = '';
    this.persona.nombres = '';
    this.persona.apellidos = '';
    this.persona.edad;
    this.persona.sexo = '';
    this.persona.ciudad = '';
    this.persona.departamento = '';

    this.formGroupPersona = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombres: [this.persona.nombres, Validators.required],
      apellidos: [this.persona.apellidos, Validators.required],
      edad: [this.persona.edad, [Validators.required, Validators.min(1), Validators.max(100)]],
      sexo: [this.persona.sexo, [Validators.required, this.validaSexo]],
      ciudad: [this.persona.ciudad, Validators.required],
      departamento: [this.persona.departamento, Validators.required]
    });
  }

  private buildFormAyuda(){
    this.ayuda = new Ayuda();
    this.ayuda.fecha = '';
    this.ayuda.modalidad = '';
    this.ayuda.valorAyuda;

    this.formGroupAyuda = this.formBuilder.group({
      fecha: [this.ayuda.fecha, Validators.required],
      modalidad: [this.ayuda.modalidad, Validators.required],
      valorAyuda: [this.ayuda.valorAyuda, [Validators.required, Validators.min(1)]]
    });
  }

  private validaSexo(control: AbstractControl) {
     const sexo = control.value;
     if (sexo.toLocaleUpperCase() !== 'M' && sexo.toLocaleUpperCase() !== 'F') {
      return { validSexo: true, messageSexo: 'Sexo No Valido' 	};
     }
     return null;
  }

  get control() { 
    return this.formGroupPersona.controls && this.formGroupAyuda.controls;
  }
    
  onSubmit() {
        if (this.formGroupPersona.invalid || this.formGroupAyuda.invalid) {
          return;
        }
        this.add();
  }

  add() {
    this.persona = this.formGroupPersona.value;
    this.ayuda = this.formGroupAyuda.value;
    this.ayuda.ayudaId = this.persona.identificacion;
    this.persona.ayuda = this.ayuda;
    this.personaService.verificarDuplicado(this.persona).subscribe(p => {
      if(p){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'La persona ya se encuentra registrada';
      }else {
        this.ayudaService.verificarAyuda(this.ayuda).subscribe(p => {
          if(p){
            const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'El valor digitado excede el valor disponible';
          }else {
            this.personaService.post(this.persona).subscribe(p => {
              if (p != null) {
                this.ayudaService.post(this.ayuda).subscribe(r => {
                  if(r != null) {
                    const messageBox = this.modalService.open(AlertModalComponent)
                    messageBox.componentInstance.title = "Resultado Operación";
                    messageBox.componentInstance.message = 'Persona creada!!! :-)';
                    this.persona = p;
                  }
                })
              }
            });
          }
        })
      }
    })
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
