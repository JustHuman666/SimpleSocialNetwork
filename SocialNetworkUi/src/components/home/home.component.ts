import { Component} from '@angular/core';
import { AuthService } from 'src/services/auth-service/auth.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent{
  constructor(private authService: AuthService) {
  }

  public get isLoggedIn() : boolean {
    return this.authService.isAuthenticated();
  }
}
