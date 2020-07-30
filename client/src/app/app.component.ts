import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <div>
    <nav class="nav">
      <a class="nav-link active" href="#">Main</a>
      <a class="nav-link" href="#">Register</a>
      <a class="nav-link" href="#">Login</a>
      <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
    </nav>
    <router-outlet></router-outlet>
  </div>`
})
export class AppComponent {
}
