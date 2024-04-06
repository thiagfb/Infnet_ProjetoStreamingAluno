import { Usuario } from './../model/usuario';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "https://localhost:7128/api/Usuario"

  constructor(private http: HttpClient) { }

  public autenticar(email:String, senha: String) : Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/login`, {
      email:email,
      senha:senha
    });
  }

  public addUsuario(data: Usuario):  Observable<any> {
    return this.http.post(`${this.url}`, {
        id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        nome: data.nome,
        email: data.email,
        senha: data.senha,
        telefone: data.telefone,
        dtNascimento: "1982-01-24T03:00:55.849Z",
        planoId: data.planoId,
        cartao: data.cartao
    }
    );
  }
}
