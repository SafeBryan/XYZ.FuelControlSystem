import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { VehiculoFormComponent } from './vehiculo-form/vehiculo-form/vehiculo-form.component';

@NgModule({
  declarations: [
     
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    VehiculoFormComponent // Componente standalone se importa aquí
  ],
  
})
export class AppModule { }
