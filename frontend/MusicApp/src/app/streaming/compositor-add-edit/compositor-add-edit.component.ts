import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Component, Inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { FormBuilder, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import { CompositorService } from '../../services/compositor.service';
import { Injectable } from '@angular/core';
import { Dialog, DialogRef } from '@angular/cdk/dialog';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CoreService } from '../../core/core.service';

@Component({
  selector: 'app-compositor-add-edit',
  standalone: true,
  imports: [MatInputModule,
    MatFormFieldModule,
    RouterOutlet,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatDialogModule,
    ReactiveFormsModule],
  templateUrl: './compositor-add-edit.component.html',
  styleUrl: './compositor-add-edit.component.css'
})

export class CompositorAddEditComponent implements OnInit {
  empForm: FormGroup;

  constructor(private _fb: FormBuilder,
              private _compService: CompositorService,
              private _dialogRef: MatDialogRef<CompositorAddEditComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private _coreService: CoreService) {
    this.empForm = this._fb.group({
      id: "",
      nome: ""
    })
  }

  ngOnInit(): void {
    this.empForm.patchValue(this.data);
  }

  onFormSubmit() {
    if(this.empForm.valid){
      if (this.data) {
        this._compService.UpdateCompositor(this.empForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Compositor atualizado com sucesso');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
      else{
        this._compService.addCompositor(this.empForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Compositor incluído com sucesso');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}
