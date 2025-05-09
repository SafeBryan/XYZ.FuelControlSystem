import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

import { MenuService, IMenu } from '../../services/menu.service';
import { IconService } from '../../services/icon.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, RouterModule, MatListModule, MatIconModule],
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent {
  listMenu: IMenu[];

  menuSrv = inject(MenuService);
  iconSrv = inject(IconService);
  matRegistry = inject(MatIconRegistry);
  sanitizer = inject(DomSanitizer);

  constructor() {
    this.listMenu = this.menuSrv.getMenu();
    this.iconSrv.getIcon().forEach((icon) => {
      this.matRegistry.addSvgIcon(
        icon.name,
        this.sanitizer.bypassSecurityTrustResourceUrl(icon.path)
      );
    });
  }
}
