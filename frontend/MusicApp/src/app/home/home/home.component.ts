import { Component } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatMenuModule} from '@angular/material/menu';
import { MatMenuTrigger } from '@angular/material/menu';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatIconModule, MatButtonModule, MatGridListModule, MatMenuModule,  MatMenuTrigger],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  currentUserEmail: string;

  constructor(private router: Router) {
    const emailFromStorage = sessionStorage.getItem('user');

    this.currentUserEmail = emailFromStorage !== null ? emailFromStorage : ''; // Definir uma string vazia como padrão se for null
  }

  public Compositor() {
    this.router.navigate(["/compositor"]);
  }
}
