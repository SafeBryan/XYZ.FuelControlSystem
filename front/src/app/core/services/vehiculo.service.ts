// core/services/vehiculo.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Vehiculo {
  id?: string;
  placa: string;
  modelo: string;
  estado: string;
  tipo: 'Liviana' | 'Pesada';
}

@Injectable({
  providedIn: 'root',
})
export class VehiculoService {
  private apiUrl = 'http://localhost:5000/api/vehiculos';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Vehiculo[]> {
    return this.http.get<Vehiculo[]>(this.apiUrl);
  }

  create(vehiculo: Vehiculo): Observable<any> {
    return this.http.post(this.apiUrl, vehiculo);
  }

  update(id: string, vehiculo: Vehiculo): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, vehiculo);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
