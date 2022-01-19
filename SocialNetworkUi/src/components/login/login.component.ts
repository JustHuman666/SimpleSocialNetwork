import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/services/auth-service/auth.service';
import { Error } from 'src/error-handle/error';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html', 
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) {
  }
  
  loginForm!: FormGroup;
  loginError!: string;
  
  ngOnInit() {
    this.loginError = '';
    this.loginForm = new FormGroup({
      email: new FormControl(),
      password: new FormControl()
    });
  }
  
  login(){
    this.authService.logIn(this.loginForm.controls['email'].value, this.loginForm.controls['password'].value)
      .subscribe(() => {
        this.router.navigate([''])
      }, 
      (exception) => {
        this.loginError = Error.returnErrorMessage(exception);;
      });
  }
}