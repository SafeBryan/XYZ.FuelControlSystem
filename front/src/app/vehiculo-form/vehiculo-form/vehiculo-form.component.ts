import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  VehiculoService,
  Vehiculo,
} from '../../core/services/vehiculo.service';

@Component({
  selector: 'app-vehiculo-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vehiculo-form.component.html',
  styleUrls: ['./vehiculo-form.component.css'],
})
export class VehiculoFormComponent {
  vehiculo: Vehiculo = {
    placa: '',
    modelo: '',
    estado: '',
    tipo: 'Liviana',
  };

  @Output() registrado = new EventEmitter<void>();

  constructor(private vehiculoService: VehiculoService) {}

  registrarVehiculo() {
    this.vehiculoService.create(this.vehiculo).subscribe({
      next: () => {
        alert('Vehículo registrado correctamente');
        this.registrado.emit();
        this.vehiculo = { placa: '', modelo: '', estado: '', tipo: 'Liviana' };
      },
      error: () => alert('Error al registrar'),
    });
  }
}
