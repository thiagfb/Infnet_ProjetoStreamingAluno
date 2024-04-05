import { Component, Inject, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormControl, FormsModule, Validators, ReactiveFormsModule} from '@angular/forms';


@Component({
  selector: 'app-login-add',
  standalone: true,
  imports: [MatInputModule, FormsModule, MatFormFieldModule, ReactiveFormsModule],
  templateUrl: './login-add.component.html',
  styleUrl: './login-add.component.css'
})

export class LoginAddComponent {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  constructor(
  )
  {

  }
}
