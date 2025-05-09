import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatButtonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  systemName = 'Sistema de Control de Combustible - XYZ';
  username = 'admin';

  constructor(private router: Router) {}

  logout() {
    localStorage.clear(); // o tu lógica personalizada
    this.router.navigate(['/login']);
  }
}
