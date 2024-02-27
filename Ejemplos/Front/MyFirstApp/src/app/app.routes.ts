import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { AdminComponent } from './components/dashboard/admin/admin.component';
import { ExamplesComponent } from './components/examples/examples.component';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { WelcomeComponent } from './components/start/welcome/welcome.component';

export const routes: Routes = [
  { path: '', redirectTo: '/welcome', pathMatch: 'full' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'documentation', component: ExamplesComponent },
  {
    path: 'admin',children: [
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: AdminComponent },
    ],
  },
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' },
];
