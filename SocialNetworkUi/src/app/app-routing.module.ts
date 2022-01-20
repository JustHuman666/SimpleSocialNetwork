import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from 'src/components/login/login.component';
import { HomeComponent } from 'src/components/home/home.component';
import { ProfileComponent } from 'src/components/profile/profile.component';

import { IsLoggedIn } from 'src/guards/is-logged-in';
import { IsNotLoggedIn } from 'src/guards/is-not-logged-in';

import { RegisterComponent } from 'src/components/register/register.component';
import { ChangePasswordComponent } from 'src/components/change-password/change-password.component';
import { FriendsComponent } from 'src/components/friends/friends.component';
import { FriendProfileComponent } from 'src/components/friend-profile/friend.profile.component';
import { SearchComponent } from 'src/components/search/search.component';
import { ChatsComponent } from 'src/components/chats/chats.component';
import { ChatMessagesComponent } from 'src/components/chat-messages/chat.messages.component';
import { MessageComponent } from 'src/components/message/message.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "login", component: LoginComponent, canActivate: [IsNotLoggedIn]},
  {path: "profile", component: ProfileComponent, canActivate: [IsLoggedIn]},
  {path: "register", component: RegisterComponent, canActivate: [IsNotLoggedIn]},
  {path: "change-password", component: ChangePasswordComponent, canActivate: [IsLoggedIn]},
  {path: "friends", component: FriendsComponent, canActivate: [IsLoggedIn]},
  {path: "friend-profile", component: FriendProfileComponent, canActivate: [IsLoggedIn]},
  {path: "search", component: SearchComponent, canActivate: [IsLoggedIn]},
  {path: "chats", component: ChatsComponent, canActivate: [IsLoggedIn]},
  {path: "chat-messages/:id", component: ChatMessagesComponent, canActivate: [IsLoggedIn]},
  {path: "message", component: MessageComponent, canActivate: [IsLoggedIn]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
