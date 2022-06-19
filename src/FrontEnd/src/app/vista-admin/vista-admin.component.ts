
import { Component, ViewChild, OnInit } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { FormsModule, FormGroup, FormControl, Validators, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Angulartics2GoogleAnalytics } from 'angulartics2';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { APIService } from '../api.service';
import { Papa } from "ngx-papaparse";

export interface CampeonatoElement {
  nombre: string,
  fecha_inicio: string,
  fecha_fin: string,
  llave: number
}

const CAMPEONATO_DATA: CampeonatoElement[] = [];

@Component({
  selector: 'app-vista-admin',
  templateUrl: './vista-admin.component.html',
  styleUrls: ['./vista-admin.component.css']
})


export class VistaAdminComponent implements OnInit {

  csvContent: string;
  contacts: Array<any> = [];
  properties:any = "";
  flag:boolean = false;

  nombre_campeonato: string;
  fecha_inicio: string;
  fecha_fin: string;
  hora_inicio: string;
  reglas: string;
  llave: any

  DATOS:any

  countryFormControl = new FormControl();
  countryFormGroup: FormGroup;

  nombre_carrera: any;
  fecha_inicio_carrera: any;
  fecha_fin_carrera: any;
  hora_fin_carrera: any
  hora_inicio_carrera: any;
  pais: any

  dataSourceCampeonato = CAMPEONATO_DATA;
  displayedColumnsCampeonato: string[] = ['nombre', 'fecha_inicio', 'fecha_fin', 'llave'];

  @ViewChild('campeonato') tablaCampeonato: MatTable<CampeonatoElement>;

  agregarCampeonato() {
    this.llave = Math.floor(Math.random() * 1000000)
    console.log(CAMPEONATO_DATA)

    if (CAMPEONATO_DATA.some(e => e.llave === this.llave)) {
      alert("Llave generada existente, intente de nuevo")
    } else if (CAMPEONATO_DATA.some(e => e.nombre === this.nombre_campeonato)) {
      alert("Nombre ya existente, intente con otro nombre")
    } else if (CAMPEONATO_DATA.some(e => e.fecha_inicio === this.fecha_inicio)) {
      alert("Esta fecha ya está reservada, escoga una diferente")
    } else if (CAMPEONATO_DATA.some(e => e.fecha_fin === this.fecha_fin)) {
      alert("Esta fecha ya está reservada, escoga una diferente")
    } else if (!this.nombre_campeonato || !this.fecha_fin || !this.fecha_inicio || !this.hora_inicio || !this.reglas) {
      alert("Rellena todos los campos obligatorios")
    }

    else {
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

  constructor(private formBuilder: FormBuilder, angulartics2GoogleAnalytics: Angulartics2GoogleAnalytics,private papa: Papa, public API: APIService) {
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
  


    parseCsvData(csvData) {
    this.papa.parse(csvData, {
      complete: result => {
        console.log("Parsed: ", result);
      }
    });
  }

  parseCsvFile(file) {
    this.papa.parse(file, {
      header: true,
      dynamicTyping: true,
      skipEmptyLines: 'greedy',
      worker: true,
      chunk: chunk =>{
        console.log(chunk.data)
        this.DATOS = chunk.data
      },
    });
  }


  handleUpload($event: any) {
    const fileList = $event.srcElement.files;
    this.parseCsvFile(fileList[0]);
  }

  actualizar(){
    const lista_id_piloto = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20]
    const lista_id_escuderia = [1,2,3,4,5,6,7,8,9]
    
    var lista_puntajes_pilotos = []
    var lista_puntajes_escuderias = []

    var url_pilotos = '/api/Piloto'
    var url_escuderia = '/api/Escuderia'

    var api: APIService


    ///////////// PILOTOS ///////////////

    for (var i = 0; i < 20; i++) {
      var update_piloto = {
        nombre: this.DATOS[i]['Nombre'],
        puntaje: this.DATOS[i]['Total de puntos'],
        precio: this.DATOS[i]['Precio'] * 1000000
      }
      lista_puntajes_pilotos.push(update_piloto)
    }
  
    for(var j = 0;j < lista_id_piloto.length ;j++){
      console.log(url_pilotos + '/' + lista_id_piloto[j].toString())
      console.log(lista_puntajes_pilotos[j])

      this.API.PUT(url_pilotos + '/' + lista_id_piloto[j].toString(),lista_puntajes_pilotos[j]).subscribe(response => {
        console.log('Pilotos actualizados')
      })
    }
    
    ///////////// ESCUDERIAS ///////////////

    for(var x = 20;x < 30; x++){
      var update_escuderia = {
        puntaje: this.DATOS[i]['Total de puntos'],
        precio: this.DATOS[i]['Precio'] * 1000000
      }
      lista_puntajes_escuderias.push(update_escuderia)
    }

    for(var y=0;y<lista_id_escuderia.length;y++){
      console.log(url_escuderia + '/' + lista_id_escuderia[y].toString())
      console.log(lista_puntajes_escuderias[y])

      this.API.PUT(url_escuderia + '/' + lista_id_escuderia[y].toString(),lista_puntajes_escuderias[y]).subscribe(response => {
        console.log('Escuderias actualizadas')
      })
    }
  }
}
