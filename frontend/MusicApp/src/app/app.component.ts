import { MatFormFieldModule } from '@angular/material/form-field';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet, Routes } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CompositorAddEditComponent } from './streaming/compositor-add-edit/compositor-add-edit.component';
import { HttpClientModule } from '@angular/common/http';
import { CompositorService } from './services/compositor.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CoreService } from './core/core.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule, MatFormFieldModule, RouterOutlet, MatToolbarModule, MatButtonModule, MatIconModule, MatMenuModule, MatDialogModule, MatPaginator, MatTableModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
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
    private _coreService: CoreService){}

  ngOnInit(): void {
      this.getCompositorList();
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
