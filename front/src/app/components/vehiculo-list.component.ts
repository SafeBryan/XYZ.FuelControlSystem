import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VehiculoService, Vehiculo } from '../core/services/vehiculo.service';

@Component({
  selector: 'app-vehiculo-list',
  standalone: true,
  imports: [CommonModule, FormsModule], // 👈 Importa FormsModule aquí
  templateUrl: './vehiculo-list.component.html',
  styleUrls: ['./vehiculo-list.component.css'],
})
export class VehiculoListComponent implements OnInit {
  vehiculos: Vehiculo[] = [];
  mostrarFormulario = false;

  vehiculo: Vehiculo = {
    placa: '',
    modelo: '',
    estado: '',
    tipo: 'Liviana',
  };

  constructor(private vehiculoService: VehiculoService) {}

  ngOnInit(): void {
    this.cargarVehiculos();
  }

  cargarVehiculos() {
    this.vehiculoService.getAll().subscribe((data) => (this.vehiculos = data));
  }

  eliminar(id: string) {
    if (confirm('¿Seguro que deseas eliminar?')) {
      this.vehiculoService.delete(id).subscribe(() => this.cargarVehiculos());
    }
  }

  abrirFormulario() {
    this.mostrarFormulario = true;
  }

  cerrarFormulario() {
    this.mostrarFormulario = false;
    this.vehiculo = {
      placa: '',
      modelo: '',
      estado: '',
      tipo: 'Liviana',
    };
  }

  registrarVehiculo() {
    this.vehiculoService.create(this.vehiculo).subscribe(() => {
      this.cargarVehiculos();
      this.cerrarFormulario();
    });
  }
}
