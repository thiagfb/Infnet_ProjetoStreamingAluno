import { Component } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatMenuTrigger } from '@angular/material/menu';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatIconModule, MatButtonModule, MatGridListModule, MatMenuModule,  MatMenuTrigger],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  currentUser: string;
  idUsuario: string;

  constructor(private router: Router) {
    const emailFromStorage = sessionStorage.getItem('user');
    const idUsuario = sessionStorage.getItem('idUsuario');

    this.currentUser = emailFromStorage !== null ? JSON.parse(emailFromStorage) : '';
    this.idUsuario = idUsuario !== null ? JSON.parse(idUsuario) : '';
  }

  public Compositor() {
    this.router.navigate(["/compositor"]);
  }

  public Banda() {
    sessionStorage.setItem("user", JSON.stringify(this.currentUser));
    sessionStorage.setItem("idUsuario", JSON.stringify(this.idUsuario));

    this.router.navigate(["/banda"]);
  }
}
