
import { Component,ViewChild, OnInit } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { FormsModule, FormGroup, FormControl, Validators, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Angulartics2GoogleAnalytics } from 'angulartics2';

export interface CampeonatoElement {
  nombre:string,
  fecha_inicio:string,
  fecha_fin:string,
  llave:number
}

const CAMPEONATO_DATA: CampeonatoElement[]=[];

@Component({
  selector: 'app-vista-admin',
  templateUrl: './vista-admin.component.html',
  styleUrls: ['./vista-admin.component.css']
})


export class VistaAdminComponent implements OnInit {

  nombre_campeonato: any;
  fecha_inicio:any;
  fecha_fin:any;
  hora_inicio:any;
  reglas:any;
  llave:any

  countryFormControl = new FormControl();
  countryFormGroup: FormGroup;

  nombre_carrera: any;
  fecha_inicio_carrera:any;
  fecha_fin_carrera:any;
  hora_fin_carrera:any
  hora_inicio_carrera:any;
  pais:any

  dataSourceCampeonato = CAMPEONATO_DATA;
  displayedColumnsCampeonato:string[] = ['nombre','fecha_inicio','fecha_fin','llave']; 

  @ViewChild('campeonato') tablaCampeonato: MatTable<CampeonatoElement>;

  agregarCampeonato(){
    this.llave = Math.floor(Math.random() * 1000000)
    console.log(CAMPEONATO_DATA)

    if(CAMPEONATO_DATA.some(e => e.llave === this.llave)){
      alert("Llave generada existente, intente de nuevo")
    }else if(CAMPEONATO_DATA.some(e => e.nombre === this.nombre_campeonato)){
      alert("Nombre ya existente, intente con otro nombre")
    }else if(CAMPEONATO_DATA.some(e => e.fecha_inicio === this.fecha_inicio)){
      alert("Esta fecha ya está reservada, escoga una diferente")
    }else if(CAMPEONATO_DATA.some(e => e.fecha_fin === this.fecha_fin)){
      alert("Esta fecha ya está reservada, escoga una diferente")
    }else if(!this.nombre_campeonato || !this.fecha_fin || !this.fecha_inicio || !this.hora_inicio || !this.reglas){
      alert("Rellena todos los campos obligatorios")
    }

    else{
      var lista_elementos = {
        nombre: this.nombre_campeonato,
        fecha_inicio: this.fecha_inicio,
        fecha_fin: this.fecha_fin,
        llave: this.llave 
      }

      CAMPEONATO_DATA.push(lista_elementos)
      this.tablaCampeonato.renderRows();
    }
  }

  constructor(private formBuilder: FormBuilder, angulartics2GoogleAnalytics: Angulartics2GoogleAnalytics) {
    angulartics2GoogleAnalytics.startTracking();
  }

  ngOnInit(): void {

    this.countryFormGroup = this.formBuilder.group({
      country: []
    });

    this.countryFormGroup.get('country').valueChanges
.subscribe(country => console
.log('this.countryFormGroup.get("country").valueChanges', country));

    this.countryFormControl.valueChanges
.subscribe(country => console
.log('this.countryFormControl.valueChanges', country));
  }

}
