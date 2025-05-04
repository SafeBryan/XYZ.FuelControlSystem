import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-vehiculo-form',
  standalone: true,
  templateUrl: './vehiculo-form.component.html',
  styleUrls: ['./vehiculo-form.component.css'],
  imports: [CommonModule, FormsModule]
})
export class VehiculoFormComponent {
  vehiculo = {
    placa: '',
    modelo: '',
    estado: '',
    tipo: 'Liviana'
  };

  registrarVehiculo() {
    console.log('Vehículo a registrar:', this.vehiculo);
    alert('Vehículo registrado (ver consola)');
  }
}
