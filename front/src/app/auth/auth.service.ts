import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  login(username: string, password: string): boolean {
    // Aquí puedes hacer un HTTP a tu backend real
    if (username === 'admin' && password === 'admin123') {
      localStorage.setItem('username', username);
      return true;
    }
    return false;
  }

  logout() {
    localStorage.clear();
  }

  getUsername(): string | null {
    return localStorage.getItem('username');
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('username');
  }
}
