import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Banda } from '../model/banda';
import { Observable } from 'rxjs';
import { Album } from '../model/album';

@Injectable({
  providedIn: 'root',
})
export class BandaService {
  private url = 'https://localhost:7128/api/Artista';
  private urlAlbum = 'https://localhost:7128/Artista';
  private urlMusicaFavorita = 'https://localhost:7128/Api/MusicaPlayList';

  constructor(private httpClient: HttpClient) {}
  public getBanda(): Observable<Banda[]> {
    return this.httpClient.get<Banda[]>(this.url);
  }

  public getBandaPorId(id: string): Observable<Banda> {
    return this.httpClient.get<Banda>(`${this.url}/${id}`);
  }

  public getAlbunsBanda(id: string): Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.urlAlbum}/${id}`);
  }

  public addMusicaFavorita(
    idUsuario: String,
    idMusica: String
  ): Observable<any> {
    return this.httpClient.post(this.urlMusicaFavorita, {
      usuarioId: idUsuario,
      musicaId: idMusica,
    });
  }

  public deleteMusicaFavorita(
    idUsuario: String,
    idMusica: String
  ): Observable<any> {
    return this.httpClient.delete(`${this.urlMusicaFavorita}/${idUsuario}/${idMusica}`);
  }
}


//https://localhost:7128/api/MusicaPlayList/0770afd6-a9f2-4b09-bd0a-e04b62584afe/d37c4c4e-a3f0-41dd-8ad5-e7be5e4f957e
