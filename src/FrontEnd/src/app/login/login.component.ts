import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { APIService } from '../api.service';
import {Md5} from 'ts-md5/dist/md5';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  username: string;
  passw: string;
  user_id:number;


  lista_usuarios:any = []
  lista_usuarios_recibidos:any = []
  lista_usuarios_passw:any = []

  nombre: string;
  apellido:string;
  rango_edad:string;
  pais: string;


  ///////// API ///////////
  url: string = '/api/Jugador'

  constructor(private router: Router, private API: APIService) { }


  ngOnInit(): void {


    window.localStorage.clear();
    this.API.GET(this.url)
      .subscribe(response => {
        this.lista_usuarios_recibidos = response

        this.lista_usuarios = []
        this.lista_usuarios_passw = []
        for (var i = 0; i < this.lista_usuarios_recibidos.length; i++) {

          this.lista_usuarios.push(this.lista_usuarios_recibidos[i]['nombre_usuario'])
          this.lista_usuarios_passw.push(this.lista_usuarios_recibidos[i]['contrasenia'])
        }
        console.log(this.lista_usuarios)
        console.log(this.lista_usuarios_passw)
      })

  }

  Autenticar() {
    const md5 = new Md5();
    const encrypt = md5.appendStr(this.passw).end();
    for (var i = 0; i < this.lista_usuarios.length; i++) {
      if (this.username == this.lista_usuarios[i] && encrypt == this.lista_usuarios_passw[i]) {
        this.router.navigate(['/jugador'])
      }
    }
    console.log(encrypt)
    localStorage.setItem('user',this.username)
    this.filtro_peso(this.username)
    localStorage.setItem('user_id',this.user_id.toString())

  }

  filtro_peso(username: any) {
    var filtro = this.lista_usuarios_recibidos.filter(function (el: any) {
      return el.nombre_usuario == username
    })

    console.log(filtro)
    this.user_id = filtro[0]['id']

    console.log(this.user_id)
  }


  NavToRegistrarse() {
    this.router.navigate(['/registro'])
  }
}
