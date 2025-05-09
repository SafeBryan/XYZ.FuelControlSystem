import { Injectable } from '@angular/core';

export interface IMenu {
  title: string;
  url: string;
  icon: string;
}

@Injectable({ providedIn: 'root' })
export class MenuService {
  private listMenu: IMenu[] = [
    { title: 'Vehículos', url: '/vehiculos', icon: 'vehicles' },
    { title: 'Conductores', url: '/conductores', icon: 'drivers' },
    { title: 'Combustible', url: '/combustible', icon: 'fuel' },
    { title: 'Rutas', url: '/rutas', icon: 'routes' },
  ];

  getMenu() {
    return [...this.listMenu];
  }

  getMenuByUrl(url: string): IMenu {
    return this.listMenu.find(
      (menu) => menu.url.toLowerCase() === url.toLowerCase()
    ) as IMenu;
  }
}
