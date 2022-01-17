import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from 'src/components/login/login.component';
import { HomeComponent } from 'src/components/home/home.component';
import { ProfileComponent } from 'src/components/profile/profile.component';

import { IsLoggedIn } from 'src/guards/is-logged-in';
import { IsNotLoggedIn } from 'src/guards/is-not-logged-in';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "login", component: LoginComponent, canActivate: [IsLoggedIn]},
  {path: "profile", component: ProfileComponent, canActivate: [IsNotLoggedIn]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
