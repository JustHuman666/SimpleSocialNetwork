import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { UserService } from "src/services/user-service/user.service";
import { FriendsService } from "src/services/friends-service/friends.service";

import { GetUser } from "src/interfaces/get-user";
import { LoggedUserProfile } from "src/interfaces/logged-user-profile";

import { Error } from "src/error-handle/error";

@Component({
    selector: 'friend-profile',
    templateUrl: './friend.profile.component.html',
    styleUrls: ['./friend.profile.component.css']
})
  

export class FriendProfileComponent implements OnInit{

    constructor(private userService: UserService,
        private friendsService: FriendsService,
        private router: Router) {
           
    }
    ngOnInit(): void {
        
        this.friendsError = '';
        this.showFriends = false;
        this.userService.getThisUserProfile().subscribe(
            (data) => {
                this.loggedUser = data;
            }
        );
        this.userService.getUserRoles().subscribe(
            (data) => {
                this.isAdmin = data.includes("Admin");
            }
        ); 
        this.friendsService.getUserFriendsById(this.User.id).subscribe(
            (data) => {
                data.forEach((user) => {
                    this.userFriends.push(user.userName);
                })
                this.friendsCount = data.length;
            },
            (exception) =>{
                this.friendsError = Error.returnErrorMessage(exception);
            }
        );
    }
    @Input() User!: GetUser;

    showFriends!: boolean;

    userFriends: string[] = [];
    
    loggedUser!: LoggedUserProfile;

    isAdmin!: boolean;

    friendsError!: string;

    friendsCount: number = 0;

    changeFriendsStatus(){
        if(this.showFriends){
            this.showFriends = false;
        }
        else{
            this.showFriends = true;
        }
    }

    public get areFriends() : boolean {
        let logedUserFriendOfHim = this.User.thisUserFriendIds.includes(this.loggedUser.id);
        let thisUserFriendOfLogged = this.loggedUser.thisUserFriendIds.includes(this.User.id)
        return logedUserFriendOfHim && thisUserFriendOfLogged;
    }

    public get isInvited() : boolean {

        var thisUserIsInvited = this.User.thisUserFriendIds.includes(this.loggedUser.id);
        return !this.areFriends && thisUserIsInvited;
    }

    public get isLoggedUserInvited() : boolean {
        var loggedUserMayInvited = this.loggedUser.thisUserFriendIds.includes(this.User.id);
        return loggedUserMayInvited && !this.areFriends;
    }

    public get canInvite(){
        if(!this.areFriends && !this.isInvited && !this.isLoggedUserInvited){
            return true;
        }
        return false;
    }

    inviteForFriendship(){
        this.friendsService.sendInvitationForFriendship(this.User.id).subscribe(
            () => {
                alert("You sent invitation for friendship to this user. Now wait for confirming.");
                this.User.thisUserFriendIds.push(this.loggedUser.id);
            },
            (exception) =>{
                alert(Error.returnErrorMessage(exception));
            }
        );
    }

    confirmFriendship(){
        this.friendsService.confirmFriendship(this.User.id).subscribe(
            () => {
                alert("You confirm friendship with this user. Congrat with new friend!");
                this.loggedUser.thisUserFriendIds.push(this.User.id);
                window.location.reload();
            },
            (exception) =>{
                alert(Error.returnErrorMessage(exception));
            }
            
        );
    }

    deleteFriend(){
        if(confirm("Are you sure, you want to delete this user from friends?")){
            this.friendsService.deleteFriendById(this.User.id).subscribe(
                () => {
                    alert("You delete this user from your friends.");
                    this.loggedUser.thisUserFriendIds.forEach((user, index) => {
                        if(user == this.User.id){
                            this.loggedUser.thisUserFriendIds.splice(index, 1);
                        }
                    });
                    window.location.reload();
                },
                (exception) =>{
                    alert(Error.returnErrorMessage(exception));
                }
            );
        }
    }

    deleteUser(){
        if(confirm("Are you sure, you want to delete this user?")){
            this.userService.deleteUserById(this.User.id).subscribe(
                () => {
                    alert("You delete this user from your friends.");
                    this.loggedUser.thisUserFriendIds.forEach((user, index) => {
                        if(user == this.User.id){
                            this.loggedUser.thisUserFriendIds.splice(index, 1);
                        }
                    });
                    window.location.reload();
                },
                (exception) =>{
                    alert(Error.returnErrorMessage(exception));
                }
            );
        }
    }
    
}
  