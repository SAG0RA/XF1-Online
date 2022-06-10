
import { Component,ViewChild, OnInit } from '@angular/core';
import { MatTable } from '@angular/material/table';

import {MatDialog,MatDialogConfig} from '@angular/material/dialog';
import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';

export interface MiembroElement {
  nombre:string
}

const MIEMBRO_DATA: MiembroElement[]=[];

@Component({
  selector: 'app-crear-liga',
  templateUrl: './crear-liga.component.html',
  styleUrls: ['./crear-liga.component.css']
})
export class CrearLigaComponent implements OnInit {

  dataSourceMiembro = MIEMBRO_DATA;
  @ViewChild('miembros') tablaMiembros: MatTable<MiembroElement>;
  displayedColumnsEquipo:string[] = ['nombre','actions']; 
  
  constructor() { }

  ngOnInit(): void {
    var sexo = {
      nombre: 'El mejor'
    }

    MIEMBRO_DATA.push(sexo)
    this.tablaMiembros.renderRows()
  }

}
