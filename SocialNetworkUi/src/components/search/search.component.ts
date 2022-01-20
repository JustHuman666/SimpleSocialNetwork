import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormControl, FormGroup } from '@angular/forms';

import { UserService } from "src/services/user-service/user.service";
import { AuthService } from "src/services/auth-service/auth.service";
import { Error } from "src/error-handle/error";
import { GetUser } from "src/interfaces/get-user";
import { LoggedUserProfile } from "src/interfaces/logged-user-profile";

@Component({
    selector: 'search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})

export class SearchComponent implements OnInit {

    constructor(private userService: UserService, 
        private authService: AuthService,
        private router: Router) {
        }

    
    allUserError!: string;

    phoneError!: string;

    userNameError!: string;

    fullNameError!: string;

    canShow!: boolean;

    allUsers: GetUser[] = [];

    foundUsersByName: GetUser[] = [];

    foundUser!: GetUser;

    phoneForm!: FormGroup;

    userNameForm!: FormGroup;

    fullNameForm!: FormGroup;

    ngOnInit(): void {

        this.allUserError = '';

        this.phoneError = '';

        this.userNameError = '';

        this.fullNameError = '';

        this.canShow = false;
    
        this.userService.getAllUsers().subscribe(
            (data) => {
                this.allUsers = data;
                let thisUserId = this.authService.getUserId();
                this.allUsers.forEach((user, index) => {
                    if(user.id == thisUserId){
                        this.allUsers.splice(index, 1);
                    }
                })
            },
            (exception) =>{
                this.allUserError = Error.returnErrorMessage(exception);
            });
    
    }

    findByPhone(){
        this.userService.getUserProfileByPhone(this.phoneForm.value.phoneNumber).subscribe(
            (data) => {
                this.foundUser = data;
                this.canShow = true;
                this.phoneForm.reset();
            },
            (exception) =>{
                this.phoneError = Error.returnErrorMessage(exception);
            }
        );
    }

    findByUserName(){
        this.userService.getUserProfileByUserName(this.userNameForm.value.userName).subscribe(
            (data) => {
                this.foundUser = data;
                this.canShow = true;
                this.userNameForm.reset();
            },
            (exception) =>{
                this.userNameError = Error.returnErrorMessage(exception);
            }
        );
    }

    findByFullName(){
        this.userService.getUserProfilesByFullName(this.fullNameForm.value.firstName, this.fullNameForm.value.lastName).subscribe(
            (data) => {
                if(data.length != 0){
                    this.foundUsersByName = data;
                    this.canShow = true;
                    this.fullNameForm.reset();
                }
                else{
                    this.fullNameError = "Can't find any user with such full name."
                }
                
            },
            (exception) =>{
                this.fullNameError = Error.returnErrorMessage(exception);
            }
        );
    }

    updateForm(){
        this.canShow = false;

        this.userNameForm = new FormGroup({
            userName: new FormControl()
        });

        this.phoneForm = new FormGroup({
            phoneNumber: new FormControl()
        });

        this.fullNameForm = new FormGroup({
            firstName: new FormControl(),
            lastName: new FormControl()
        });
    }

}
  