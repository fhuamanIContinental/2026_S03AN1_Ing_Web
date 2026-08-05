import { DOCUMENT } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink, RouterLinkActive, RouterOutlet],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Dashboard {
  private readonly document = inject(DOCUMENT);

  readonly sidebarCollapsed = signal(false);
  readonly darkMode = signal(false);

  constructor() {
    const currentTheme = this.document.documentElement.getAttribute('data-bs-theme');
    this.darkMode.set(currentTheme === 'dark');
  }

  toggleSidebar(): void {
    this.sidebarCollapsed.update((value) => !value);
  }

  toggleDarkMode(): void {
    const nextMode = !this.darkMode();
    this.darkMode.set(nextMode);
    this.document.documentElement.setAttribute('data-bs-theme', nextMode ? 'dark' : 'light');
  }

}
