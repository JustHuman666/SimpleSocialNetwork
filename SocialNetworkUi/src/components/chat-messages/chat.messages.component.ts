import { Component, OnInit } from "@angular/core";
import { Router,  ActivatedRoute } from "@angular/router";

import { UserService } from "src/services/user-service/user.service";
import { AuthService } from "src/services/auth-service/auth.service";
import { ChatService } from "src/services/chat-service/chat.service";
import { MessageService } from "src/services/message-service/message.service";

import { GetUser } from "src/interfaces/get-user";
import { CreateChat } from "src/interfaces/create-chat";

import { Error } from "src/error-handle/error";
import { GetChat } from "src/interfaces/get-chat";
import { FormControl, FormGroup } from "@angular/forms";
import { GetMessage } from "src/interfaces/get-message";
import { SendMessage } from "src/interfaces/send-message";

@Component({
    selector: 'chat-messages',
    templateUrl: './chat.messages.component.html',
    styleUrls: ['./chat.messages.component.css']
})

export class ChatMessagesComponent implements OnInit {

    constructor(private authService: AuthService,
        private chatService: ChatService,
        private messageService: MessageService,
        private userService: UserService,
        private route: ActivatedRoute) {}

    chatError!: string;

    usersError!: string;

    userError!: string;

    messagesError!: string;

    messageError!: string;

    thisChat!: GetChat;

    thisChatMessages: GetMessage[] = [];

    thisChatUsers: GetUser[] = [];

    thisChatId!: number;

    text!: FormControl;

    userName!: FormControl;
    
    ngOnInit(): void {

        this.messagesError = '';

        this.usersError = '';

        this.userError = '';

        this.messageError = '';

        this.chatError = '';

        this.thisChatId = this.route.snapshot.params['id'];

        this.text = new FormControl();

        this.userName = new FormControl();

        this.chatError = '';
        this.chatService.getChatById(this.thisChatId).subscribe(
            (data) => {
                this.thisChat = data;
            },
            (exception) => {
                this.chatError = Error.returnErrorMessage(exception);
            }
        );
        this.chatService.getUsersOfChatById(this.thisChatId).subscribe(
            (data) => {
                this.thisChatUsers = data;
            },
            (exception) => {
                this.usersError = Error.returnErrorMessage(exception);
            }
        );
        this.messageService.getChatMessages(this.thisChatId).subscribe(
            (data) => {
                this.thisChatMessages = data;
            },
            (exception) => {
                this.messagesError = Error.returnErrorMessage(exception);
            }
        );
    }

    sendMessage(){
        let newMessage: SendMessage = {
            text: this.text.value,
            senderId: this.authService.getUserId(),
            chatId: this.thisChat.id
        }
        this.messageService.sendNewMessageInChat(newMessage).subscribe(
            (data) => {
                window.location.reload();
            },
            (exception) => {
                this.messageError = Error.returnErrorMessage(exception);
            }
        );
    }

    addNewUser(){
        this.userService.getUserProfileByUserName(this.userName.value).subscribe(
            (data) => {
                this.chatService.addUserInChat(this.thisChat.id, data.id).subscribe(
                    (data) => {
                        alert("User added.");
                        window.location.reload();
                    }
                );
            },
            (exception) =>{
                this.userError = Error.returnErrorMessage(exception);
            }
        );
    }


    
}
  