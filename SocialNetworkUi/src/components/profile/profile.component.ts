import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormControl, FormGroup } from '@angular/forms';

import { UserService } from "src/services/user-service/user.service";
import { AuthService } from "src/services/auth-service/auth.service";
import { Error } from "src/error-handle/error";

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {

    constructor(private userService: UserService, 
        private authService: AuthService,
        private router: Router) {
        }

    userName!: string;

    firstName!: string;

    lastName!: string;

    isAdmin: boolean = false;

    error!: string;

    updateForm!: FormGroup;

    ngOnInit(): void {
        this.userService.getThisUserProfile().subscribe((profile) => {
        this.userName = profile.userName;
        this.firstName = profile.firstName;
        this.lastName = profile.lastName;
        this.updateForm.setValue({
            userName: profile.userName,
            firstName: profile.firstName,
            lastName: profile.lastName,
            email: profile.email,
            phoneNumber: profile.phoneNumber
          });
        });

        this.userService.getUserRoles().subscribe(roles => {
            if(roles.includes("Admin")){
              this.isAdmin = true;
            }
          })

        this.error = '';
        this.updateForm = new FormGroup({
          userName: new FormControl(),
          firstName: new FormControl(),
          lastName: new FormControl(),
          email: new FormControl(),
          phoneNumber: new FormControl()
        });
    }

    update(){
        this.userService.updateThisUserInfo(this.updateForm.value).subscribe(
            () => {
                alert("Your profile was successfully update!");
                window.location.reload();
              },
              (exception) => {
                this.error = Error.returnErrorMessage(exception);
              }
        );
    }

    delete(){
        if(confirm("Confirm, if you want to delete your account")) {
            this.userService.deleteThisUser().subscribe(() => {
              this.authService.logOut();
              this.router.navigate(['']);
            });
        }
    }

    changePassword(){
        this.router.navigate([""]);
    }
   

   

}
  