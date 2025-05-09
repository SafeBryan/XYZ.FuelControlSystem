import { Component } from '@angular/core';
import { VehiculoFormComponent } from './vehiculo-form/vehiculo-form/vehiculo-form.component';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [VehiculoFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
}
