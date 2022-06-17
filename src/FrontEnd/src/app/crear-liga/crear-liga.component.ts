
import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { MatTable } from '@angular/material/table';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';

export interface MiembroElement {
  nombre: string
}

const MIEMBRO_DATA: MiembroElement[] = [];

@Component({
  selector: 'app-crear-liga',
  templateUrl: './crear-liga.component.html',
  styleUrls: ['./crear-liga.component.css']
})
export class CrearLigaComponent implements OnInit, OnDestroy {

  dataSourceMiembro = MIEMBRO_DATA;
  @ViewChild('miembros') tablaMiembros: MatTable<MiembroElement>;
  displayedColumnsEquipo: string[] = ['nombre'];

  nombreLiga: string
  userNameInvitado: string
  codigo: string

  constructor() { }

  ngOnInit(): void {
    var usuario = {
      nombre: 'Usuario'
    }
    MIEMBRO_DATA.push(usuario)
    this.tablaMiembros.renderRows()
  }

  ngOnDestroy() {
    MIEMBRO_DATA.splice(0, MIEMBRO_DATA.length)
  }

  agregarUsuario() {
    console.log(MIEMBRO_DATA)
    if (this.existeMiembro(MIEMBRO_DATA, { nombre: this.userNameInvitado })) {
      alert('El jugador ya ha sido agregado')

    } else {
      if (!this.userNameInvitado) {
        alert('Agrega el jugador')
      } else {
        var usuarioNuevo = {
          nombre: this.userNameInvitado
        }
        MIEMBRO_DATA.push(usuarioNuevo)
        this.tablaMiembros.renderRows()
      }
    }
    
    
    

  }

  crearLiga() {
    if (!this.nombreLiga) {
      alert('Agrega el nombre de tu liga')
    } else {
      this.codigo = this.crearCodigo()
      alert('Tu liga ha sido creada')
    }
  }



  crearCodigo() {
    var codigo = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < 10; i++)
      codigo += possible.charAt(Math.floor(Math.random() * possible.length));
    return codigo;
  }


  existeMiembro(list, obj) {
    for (var i in list) {
      if (JSON.stringify(list[i]) === JSON.stringify(obj)) {
        return true
      }
    }
    return false
  }
}
