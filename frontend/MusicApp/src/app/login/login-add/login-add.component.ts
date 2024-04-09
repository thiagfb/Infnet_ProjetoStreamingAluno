import { Usuario } from './../../model/usuario';
import { UsuarioService } from './../../services/usuario.service';
import { Component, Inject, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormControl, FormsModule, Validators, ReactiveFormsModule, FormGroup, FormBuilder} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatRadioModule} from '@angular/material/radio';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-login-add',
  standalone: true,
  imports: [MatInputModule, FormsModule, MatFormFieldModule, ReactiveFormsModule, MatButtonModule, MatIconModule, MatRadioModule],
  templateUrl: './login-add.component.html',
  styleUrl: './login-add.component.css'
})

export class LoginAddComponent implements OnInit {
  hide = true;
  usuarioForm!: FormGroup;
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  usuario: Usuario = {
    nome: '',
    email: '',
    senha: '',
    telefone: '',
    dtNascimento: '',
    planoId: '',
    cartao: ''
  };


  constructor(private _usuario: UsuarioService,
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog){
  }

  ngOnInit(): void {
    this.usuarioForm = this.fb.group({
      nome: [''],
      email: [''],
      senha: [''],
      telefone: [''],
      dtNascimento: [''],
      planoId: [''],
      cartao: ['']
    });
  }

  submitForm(){
    this._usuario.addUsuario(this.usuarioForm.value).subscribe({
        next: (response) => {

          this.usuario = response;

          sessionStorage.setItem("user", JSON.stringify(this.usuario.nome));
          sessionStorage.setItem("idUsuario", JSON.stringify(this.usuario.id));

          this.router.navigate(['/home']);
        },
        error: (err: any) => {
          console.log(err);
        },
      }
    )
  }
}
