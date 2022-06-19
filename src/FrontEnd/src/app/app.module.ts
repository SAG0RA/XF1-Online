import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectCountryModule } from '@angular-material-extensions/select-country';



import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import {HttpClientModule} from '@angular/common/http'
import {MatIconModule } from '@angular/material/icon'
import {MatMenuModule} from '@angular/material/menu';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { VistaJugadorComponent } from './vista-jugador/vista-jugador.component';
import { LoginComponent } from './login/login.component';
import { VistaAdminComponent } from './vista-admin/vista-admin.component';


import { RegistroJugadorComponent } from './registro-jugador/registro-jugador.component'  


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CrearLigaComponent } from './crear-liga/crear-liga.component';


@NgModule({
  declarations: [
    AppComponent,
    VistaJugadorComponent,
    LoginComponent,
    VistaAdminComponent,
    RegistroJugadorComponent,
    CrearLigaComponent,
  ],
  entryComponents:[CrearLigaComponent],
  imports: [
    FormsModule,
    MatTableModule,
    BrowserModule,
    MatSelectModule,
    MatDialogModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    HttpClientModule,
    MatIconModule,
    MatCheckboxModule,
    MatRadioModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectCountryModule.forRoot('es'),

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
