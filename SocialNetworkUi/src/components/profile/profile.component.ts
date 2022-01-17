import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { UserService } from "src/services/user-service/user.service";
import { AuthService } from "src/services/auth-service/auth.service";

import { GetUser } from "src/interfaces/get-user";


@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {

    constructor(private userService: UserService, 
        private authService: AuthService,
        private router: Router) {}

    friends: GetUser[] = [];

    userName!: string;

    firstName!: string;

    lastName!: string;

    email!: string;

    phoneNumber!: string;

    isAdmin: boolean = false;

    ngOnInit(): void {
        this.userService.getThisUserProfile().subscribe((profile) => {
        this.userName = profile.userName;
        this.firstName = profile.firstName;
        this.lastName = profile.lastName;
        this.email = profile.email;
        this.phoneNumber = profile.phoneNumber;
        });
    }

}
  