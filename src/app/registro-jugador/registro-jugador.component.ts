import { Component, OnInit } from '@angular/core';
import {Country} from '@angular-material-extensions/select-country';
import { FormsModule, FormGroup, FormControl, Validators, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Angulartics2GoogleAnalytics } from 'angulartics2';
import {Md5} from 'ts-md5/dist/md5';

@Component({
  selector: 'app-registro-jugador',
  templateUrl: './registro-jugador.component.html',
  styleUrls: ['./registro-jugador.component.css']
})
export class RegistroJugadorComponent implements OnInit {
  
  countryFormControl = new FormControl();
  countryFormGroup: FormGroup;

  nombre:string
  apellido:string
  nombre_usuario:string
  fecha_nac:string
  correo:string
  password:string
  pais:string

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

  onCountrySelected($event: Country) {
    console.log($event);
  }

  Registro(){
    if(!this.nombre || !this.apellido || !this.correo || !this.password || !this.pais || !this.fecha_nac || !this.nombre_usuario){
      alert("Rellena todos los espacios")
    }else{
      localStorage.setItem('user', this.nombre_usuario);
          /// Encriptacion por MD5 \\\
          const md5 = new Md5();
          const encrypt = md5.appendStr(this.password).end();
          /////////////////////////////////////////////////////
      localStorage.setItem('pass',this.password)
    }
  }

}
