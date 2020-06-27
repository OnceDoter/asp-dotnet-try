import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <div>
    <h2>
      Angular + ASP.NET Video service
    </h2>
    <router-outlet></router-outlet>
  </div>`
})
export class AppComponent {
  title = 'VideoPosting!';
}
