import { Component, OnInit } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BandaService } from '../../services/banda.service';
import { Banda } from '../../model/banda';
import { Album } from '../../model/album';
import {
  MatCheckboxChange,
  MatCheckboxModule,
} from '@angular/material/checkbox';

@Component({
  selector: 'app-banda-detail',
  standalone: true,
  imports: [MatExpansionModule, CommonModule, MatCheckboxModule],
  templateUrl: './banda-detail.component.html',
  styleUrl: './banda-detail.component.css',
})
export class BandaDetailComponent implements OnInit {
  idBanda = '';
  idUsuario = '';
  banda!: Banda;
  albuns!: Album[];

  constructor(
    private route: ActivatedRoute,
    private bandaService: BandaService
  ) {
    const idUsuario = sessionStorage.getItem('idUsuario');

    this.idUsuario = idUsuario != null ? JSON.parse(idUsuario) : '';
  }

  ngOnInit(): void {
    this.idBanda = this.route.snapshot.params['id'];

    this.bandaService.getBandaPorId(this.idBanda).subscribe((response) => {
      this.banda = response;
    });

    this.bandaService.getAlbunsBanda(this.idBanda).subscribe((response) => {
      this.albuns = response;
      console.log(this.albuns);
    });
  }

  checkboxChanged(
    event: MatCheckboxChange,
    idMusica: String,
    idArtista: String
  ) {
    if (event.checked) {
      this.bandaService.addMusicaFavorita(this.idUsuario, idMusica).subscribe({
        next: (response) => {
          console.log('gravado com sucesso');
        },
        error: (e) => {
          if (e.error) {
            console.log(e.error.error);
          }
        },
      });
    } else {
      this.bandaService
        .deleteMusicaFavorita(this.idUsuario, idMusica)
        .subscribe({
          next: (response) => {
            console.log('excluído com sucesso');
          },
          error: (e) => {
            if (e.error) {
              console.log(e.error.error);
            }
          },
        });
    }
  }
}
