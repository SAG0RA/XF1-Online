import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  passw: string;

  constructor(private router: Router) { }

  dato = localStorage.getItem('user');
  datopassw = localStorage.getItem('passw');
  
  ngOnInit(): void {
  }

  Autenticar(){
    if(!this.username || !this.passw){
      alert("Rellena todos los espacios")
    }else{
      if(localStorage.getItem('user')==this.dato && localStorage.getItem('pass')==this.passw){
        this.router.navigate(['/jugador'])
      }else{
        console.log('lmao')
      }
    }
  }

  NavToRegistrarse(){
    this.router.navigate(['/registro'])
  }
}
