import { Injectable } from '@angular/core';

interface IIcon {
  name: string;
  path: string;
}

@Injectable({ providedIn: 'root' })
export class IconService {
  private icons: IIcon[] = [
    { name: 'vehicles', path: 'assets/icons/vehicles.svg' },
    { name: 'drivers', path: 'assets/icons/drivers.svg' },
    { name: 'fuel', path: 'assets/icons/fuel.svg' },
    { name: 'routes', path: 'assets/icons/routes.svg' },
  ];

  getIcon(): IIcon[] {
    return [...this.icons];
  }

  getIconByName(name: string): IIcon {
    return this.icons.find((icon) => icon.name === name) as IIcon;
  }
}
