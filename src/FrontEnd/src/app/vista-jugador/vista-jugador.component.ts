import { CrearLigaComponent } from './../crear-liga/crear-liga.component';
import { Component,ViewChild, OnInit } from '@angular/core';
import { MatTable } from '@angular/material/table';

import {MatDialog,MatDialogConfig} from '@angular/material/dialog';
import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';

export interface PilotoElement {
  nombre:string,
  precio:string,
}

export interface LigaElement {
  nombre:string,
  codigo:string,
}

export interface EquipoElement {
  nombre:string
}

const PILOTO_DATA: PilotoElement[]=[];
const EQUIPO_DATA: EquipoElement[]=[];
const LIGA_DATA: LigaElement[] = [];


@Component({
  selector: 'app-vista-jugador',
  templateUrl: './vista-jugador.component.html',
  styleUrls: ['./vista-jugador.component.css']
})
export class VistaJugadorComponent implements OnInit {

  
  dataSourcePiloto = PILOTO_DATA;
  dataSourceEquipo = EQUIPO_DATA;
  dataSourceLiga = LIGA_DATA;


  @ViewChild('productos') table: MatTable<PilotoElement>;
  @ViewChild('pilotos') tablaPilotos: MatTable<PilotoElement>;
  @ViewChild('equipos') tablaEquipos: MatTable<PilotoElement>;
  @ViewChild('ligas') tablaLigas: MatTable<LigaElement>;


  displayedColumnsCampeonato:string[] = ['nombre','precio','actions']; 
  displayedColumnsEquipo:string[] = ['nombre','actions'];
  displayedColumnsLiga:string[] = ['nombre','codigo','actions'];  

  lista_equipos = []
  username: string = localStorage.getItem('user')

  presupuesto = 200000000

  visible:boolean = true
  nombreEquipo:string

  constructor(private dialog:MatDialog) { }

  ngOnInit(): void {
  }

  comprarPiloto(id:any,precio:any){
    if(PILOTO_DATA.length == 5){
      alert('Solo puedes tener 5 pilotos')
    }else{
      ///////////////////// Actualizacion de vista de pilotos ////////////////
      const comprados = document.querySelector('#comprados');
      var element = document.getElementById(id);
      console.log(element)
      comprados.appendChild(element)

      var lista_elementos = {
        nombre: id,
        precio: precio 
      }
      
      
      ///////////////////// Actualizacion de presupuesto /////////////////////
      this.presupuesto -= precio
      var presupuesto_lbl = document.getElementById('presupuesto')
      presupuesto_lbl.innerHTML = 'PRESUPUESTO ($):' + this.presupuesto.toString()
      

      PILOTO_DATA.push(lista_elementos)
      this.tablaPilotos.renderRows();
    }
  }

  eliminarPiloto(id:string, precio:number,row:any){

    ///////////////////// Actualizacion de vista de pilotos ////////////////
    const pilotos = document.querySelector('#compra');
    var  element = document.getElementById(id);
    console.log(element)
    pilotos.appendChild(element)


    ///////////////////// Actualizacion de presupuesto /////////////////////
    this.presupuesto += precio

    var presupuesto_lbl = document.getElementById('presupuesto')
    presupuesto_lbl.innerHTML = 'PRESUPUESTO ($):' + this.presupuesto.toString()
    

    this.dataSourcePiloto.splice(row,1);
    this.tablaPilotos.renderRows();
  }

  crearEquipo(){
    if(PILOTO_DATA.length < 5){
      alert('Agrega al menos 5 pilotos en tu equipo!')
    }else{
      if(!this.nombreEquipo){
        alert('Agrega un nombre a tu equipo!')
      }else{
        ///////////////////// Creacion de nuevo equipo con pilotos comprados  ////////////////
        var pilotos_clonados = [];
        PILOTO_DATA.forEach(val => pilotos_clonados.push(Object.assign({}, val)));
        this.lista_equipos.push(pilotos_clonados)

        var equipo_nuevo = {
          nombre:this.nombreEquipo
        }

        EQUIPO_DATA.push(equipo_nuevo)
        PILOTO_DATA.splice(0,PILOTO_DATA.length)
        this.tablaPilotos.renderRows()
        this.tablaEquipos.renderRows()

        this.nombreEquipo = ''

        alert('Tu equipo ha sido creado con éxito!')



      }
    }
  }

  ventanaCrearLiga(){
     this.dialog.open(CrearLigaComponent)
  }
}
