import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component } from '@angular/core';
import { OnInit, ViewChild, Input } from '@angular/core';
import { MatTable } from '@angular/material/table';

export interface CampeonatoElement {
  nombre:string,
  fecha_inicio:string,
  fecha_fin:string,
  llave:number
}

const CAMPEONATO_DATA: CampeonatoElement[]=[];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title='xf1-online'

  nombre_campeonato: any;
  fecha_inicio:any;
  fecha_fin:any;
  hora_inicio:any;
  reglas:any;
  llave:any

  nombre_carrera: any;
  fecha_inicio_carrera:any;
  fecha_fin_carrera:any;
  hora_fin_carrera:any
  hora_inicio_carrera:any;

  dataSourceCampeonato = CAMPEONATO_DATA;
  displayedColumnsCampeonato:string[] = ['nombre','fecha_inicio','fecha_fin','llave']; 

  @ViewChild('campeonato') tablaCampeonato: MatTable<CampeonatoElement>;

  agregarCampeonato(){
    this.llave = Math.floor(Math.random() * 1000000)
    console.log(CAMPEONATO_DATA)

    if(CAMPEONATO_DATA.some(e => e.llave === this.llave) 
    || CAMPEONATO_DATA.some(e => e.nombre === this.nombre_campeonato) 
    || CAMPEONATO_DATA.some(e => e.fecha_inicio === this.fecha_inicio)
    || CAMPEONATO_DATA.some(e => e.fecha_fin === this.fecha_fin)
    || !this.nombre_campeonato || !this.fecha_fin || !this.fecha_inicio || !this.hora_inicio || !this.reglas){
      alert("Error al registrar el campeonato")
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

}
