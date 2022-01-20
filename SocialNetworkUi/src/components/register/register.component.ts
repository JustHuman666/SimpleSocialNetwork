import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormControl, FormGroup } from '@angular/forms';

import { AuthService } from "src/services/auth-service/auth.service";

import { Error } from "src/error-handle/error";

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

    constructor(private authService: AuthService, private router: Router) {}

    registerForm!: FormGroup;

    error!: string;

    ngOnInit(): void {
        
        this.error = '';
        this.registerForm = new FormGroup({
          userName: new FormControl(),
          firstName: new FormControl(),
          lastName: new FormControl(),
          email: new FormControl(),
          phoneNumber: new FormControl(),
          password: new FormControl()
        });
    }

    register(){
        this.authService.register(this.registerForm.value).subscribe(
            () => {
                alert("Your account was successfully created! Now try to log in.");
                this.router.navigate(['']);
              },
              (exception) => {
                this.error = Error.returnErrorMessage(exception);
                
              }
        );
    }

}
  