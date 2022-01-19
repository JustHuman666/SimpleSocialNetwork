import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormControl, FormGroup } from '@angular/forms';

import { UserService } from "src/services/user-service/user.service";
import { FriendsService } from "src/services/friends-service/friends.service";

import { GetUser } from "src/interfaces/get-user";

import { Error } from "src/error-handle/error";

@Component({
    selector: 'app-friends',
    templateUrl: './friends.component.html',
    styleUrls: ['./friends.component.css']
})

export class FriendsComponent implements OnInit {

    constructor(private userService: UserService,
        private friendsService: FriendsService,
        private router: Router) {}

    friends: GetUser[] = [];

    receivedInvitations: GetUser[] = [];

    sentInvitations: GetUser[] = [];

    friendsError!: string;

    invitationsError!: string;

    invitedError!: string;

    ngOnInit(): void {
        
        this.friendsError = '';
        
        this.friendsService.getOwnFriends().subscribe(
            (data) => {
                this.friends = data;
            },
            (exception) =>{
                this.friendsError = Error.returnErrorMessage(exception);
            });

        this.friendsService.getReceivedInnvitations().subscribe(
            (data) => {
                this.receivedInvitations = data;
            },
            (exception) =>{
                this.invitationsError = Error.returnErrorMessage(exception);
            });

        this.friendsService.getSentInnvitations().subscribe(
            (data) => {
                this.sentInvitations = data;
            },
            (exception) =>{
                this.invitedError = Error.returnErrorMessage(exception);
            });
    }
}
  