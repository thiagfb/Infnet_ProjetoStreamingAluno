import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { CompositorAddEditComponent } from './streaming/compositor-add-edit/compositor-add-edit.component';

export const routes: Routes = [
  {
    path: '',
    component: CompositorAddEditComponent
  }
];
