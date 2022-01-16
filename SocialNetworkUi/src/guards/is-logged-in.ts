import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { AuthService } from 'src/services/auth-service/auth.service';

@Injectable({
  providedIn: 'root'
})

export class IsLoggedIn implements CanActivate {
  
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean{
    if(this.authService.isAuthenticated()){
      this.router.navigate([''])
    }
    return true;
  }
}