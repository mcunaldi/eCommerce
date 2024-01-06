import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToastModule],
  template: `
  
  <p-toast position="bottom-right" [life]="3000"></p-toast>
  <p-toast position="bottom-center" key="confirm" [baseZIndex]="5000">
        <ng-template let-message pTemplate="message">
            <div class="flex flex-column align-items-start" style="flex: 1">
                <div class="flex align-items-center gap-2">
                </div>
                <div class="font-medium text-lg my-3 text-900">{{ message.summary }}</div>
            </div>
        </ng-template>
    </p-toast>
  <router-outlet></router-outlet>
  `
})
export class AppComponent {}

