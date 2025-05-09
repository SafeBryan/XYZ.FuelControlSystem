import { Component } from '@angular/core';
import { VehiculoFormComponent } from './vehiculo-form/vehiculo-form/vehiculo-form.component';
import { VehiculoListComponent } from './components/vehiculo-list.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { RouterModule, RouterOutlet } from '@angular/router';
import { MenuComponent } from './shared/components/menu/menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MenuComponent, HeaderComponent, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {}
