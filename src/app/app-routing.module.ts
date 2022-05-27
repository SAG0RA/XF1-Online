import { RegistroJugadorComponent } from './registro-jugador/registro-jugador.component';
import { VistaAdminComponent } from './vista-admin/vista-admin.component';
import { LoginComponent } from './login/login.component';
import { VistaJugadorComponent } from './vista-jugador/vista-jugador.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { Angulartics2Module } from 'angulartics2';
import { Angulartics2GoogleAnalytics } from 'angulartics2';



const routes: Routes = [
  {path:'jugador',component:VistaJugadorComponent},
  {path:'',component:LoginComponent},
  {path:'admin',component:VistaAdminComponent},
  {path:'registro',component:RegistroJugadorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
            Angulartics2Module.forRoot()],
  exports: [RouterModule]
})
export class AppRoutingModule { }
