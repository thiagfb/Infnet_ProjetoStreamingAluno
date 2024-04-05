import { CoreService } from './../../core/core.service';
import { CompositorService } from './../../services/compositor.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet, Routes } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CompositorAddEditComponent } from '../compositor-add-edit/compositor-add-edit.component';
import { HttpClientModule } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';


@Component({
  selector: 'app-compositor',
  standalone: true,
  imports: [HttpClientModule, MatFormFieldModule, RouterOutlet, MatToolbarModule, MatButtonModule, MatIconModule, MatMenuModule,
            MatDialogModule, MatPaginator, MatTableModule],
  templateUrl: './compositor.component.html',
  styleUrl: './compositor.component.css'
})

export class CompositorComponent implements OnInit {
  title = 'MusicApp';

  displayedColumns: string[] = [
    'id',
    'nome',
    'action'
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _dialog: MatDialog, private _compService: CompositorService,
    private _coreService: CoreService,
    private router: Router){}

  ngOnInit(): void {
      this.getCompositorList();
  }

  openCompositor(){
    this.router.navigate(["/compositor"]);
  }

  openAddEditForm(){
    const dialogRef = this._dialog.open(CompositorAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getCompositorList();
        }
      },
    });
  }

  getCompositorList(){
    this._compService.getCompositorAll().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  deleteCompositor(id: string){
    this._compService.deleteCompositor(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Compositor excluído com sucesso', 'done');
        this.getCompositorList();
      },
      error: (err) => {
        console.log(err)
      }
    });
  }

  openEditForm(data: any) {
    const dialogRef = this._dialog.open(CompositorAddEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getCompositorList();
        }
      },
    });
  }
}
