import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root',
})

export class CompositorService {

  private apiUrl = "https://localhost:7128/api/Compositor";

  constructor(private _http: HttpClient) {}

  addCompositor(data: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.post(this.apiUrl, data, {headers} )
    .pipe(
      catchError(error => {
        console.error('Error posting data to API:', error); // Adicione esta linha para imprimir o objeto de erro completo
        throw 'Error posting data to API: ' + error;
      })
    );
  }

  getCompositorAll(): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.get(this.apiUrl, { headers } )
  }

  deleteCompositor(id: String): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.delete(`https://localhost:7128/api/Compositor/`+ id);
  }

  UpdateCompositor(data: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this._http.put(this.apiUrl, data, { headers });
  }

}
