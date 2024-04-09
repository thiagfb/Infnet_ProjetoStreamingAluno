import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BandaService } from '../../services/banda.service';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { Banda } from '../../model/banda';

@Component({
  selector: 'app-banda',
  standalone: true,
  imports: [MatCardModule, CommonModule],
  templateUrl: './banda.component.html',
  styleUrl: './banda.component.css'
})
export class BandaComponent implements OnInit {

  usuarioLogado: string;
  idUsuario: string;
  bandas = null;

  constructor (private router: Router, private bandaService: BandaService){
    const usuario = sessionStorage.getItem('user');
    const idUsuario = sessionStorage.getItem('idUsuario');

    this.usuarioLogado = usuario !== null ? JSON.parse(usuario) : '';
    this.idUsuario = idUsuario != null ? JSON.parse(idUsuario) : '';
  }

  ngOnInit(): void {
    this.bandaService.getBanda().subscribe(response => {
      console.log(response);
      this.bandas = response as any;
    });
  }

  public goToDetail(item:Banda) {
    sessionStorage.setItem("idUsuario", JSON.stringify(this.idUsuario));

    this.router.navigate(["detail", item.id]);
  }
}
