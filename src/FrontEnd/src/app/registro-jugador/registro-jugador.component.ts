import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';
import {Country} from '@angular-material-extensions/select-country';
import { FormsModule, FormGroup, FormControl, Validators, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Angulartics2GoogleAnalytics } from 'angulartics2';
import {Md5} from 'ts-md5/dist/md5';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registro-jugador',
  templateUrl: './registro-jugador.component.html',
  styleUrls: ['./registro-jugador.component.css']
})
export class RegistroJugadorComponent implements OnInit {
  
  countryFormControl = new FormControl();
  countryFormGroup: FormGroup;

  url:string = 'api/Jugador'
  lista_usuarios:any = []
  lista_usuarios_recibidos:any = []




  nombre:string
  apellido:string
  nombre_usuario:string
  fecha_nac:string
  correo:string
  password:string
  pais:string

  constructor(private router: Router,private formBuilder: FormBuilder, angulartics2GoogleAnalytics: Angulartics2GoogleAnalytics, private API: APIService) {
    angulartics2GoogleAnalytics.startTracking();
  }

  ngOnInit(): void {
    window.localStorage.clear();
    this.API.GET(this.url)
    .subscribe(response => {
      this.lista_usuarios_recibidos = response
      for (var i = 0; i < this.lista_usuarios_recibidos.length; i++) {
        this.lista_usuarios.push(this.lista_usuarios_recibidos[i])
      }
      console.log(this.lista_usuarios)
    })

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
    }else if(this.lista_usuarios.includes(this.correo) ){
      alert("Este usuario ya esta registrado")
    }
    else{

      const md5 = new Md5();
      const encrypt = md5.appendStr(this.password).end();

      var post = {
        id:Math.floor(Math.random() * 1000000),
        nombre_usuario:this.nombre_usuario,
        nombre:this.nombre,
        apellido:this.apellido,
        correo:this.correo,
        rango_edad:this.fecha_nac,
        pais:this.pais['name'],
        contrasenia:encrypt
      }

      this.API.POST(this.url, post).subscribe(response => {
        console.log('Jugador agregado')
      })
      

      this.router.navigate([''])
    }
  }

}
