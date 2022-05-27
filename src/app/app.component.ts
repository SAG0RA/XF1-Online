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
}
