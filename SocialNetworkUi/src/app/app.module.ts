import { ChangeDetectorRef, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DatePipe} from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatMenuModule } from '@angular/material/menu';
import {MatDividerModule} from '@angular/material/divider';
import {MatTabsModule} from '@angular/material/tabs'; 
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatTreeModule} from '@angular/material/tree'; 

import { SOCIAL_NETWORK_API_URL } from 'src/injection/injection-token';
import { UNIQUE_USER_TOKEN_KEY } from 'src/services/auth-service/auth.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/services/auth-service/jwt.interceptor';
import { JwtModule } from '@auth0/angular-jwt';

import { LoginComponent } from 'src/components/login/login.component';
import { HomeComponent } from 'src/components/home/home.component';
import { ProfileComponent } from 'src/components/profile/profile.component';
import { RegisterComponent } from 'src/components/register/register.component';
import { ChangePasswordComponent } from 'src/components/change-password/change-password.component';
import { FriendsComponent } from 'src/components/friends/friends.component';
import { FriendProfileComponent } from 'src/components/friend-profile/friend.profile.component';
import { SearchComponent } from 'src/components/search/search.component';
import { ChatsComponent } from 'src/components/chats/chats.component';
import { ChatMessagesComponent } from 'src/components/chat-messages/chat.messages.component';
import { MessageComponent } from 'src/components/message/message.component';

export function getToken() {
  return localStorage.getItem(UNIQUE_USER_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ProfileComponent,
    RegisterComponent,
    ChangePasswordComponent,
    FriendsComponent,
    FriendProfileComponent,
    SearchComponent,
    ChatsComponent,
    ChatMessagesComponent,
    MessageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatSelectModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatDividerModule,
    MatTabsModule,
    MatButtonToggleModule,
    MatTreeModule,

    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        allowedDomains: [environment.tokenDomain]
      }
    })

  ],
  
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
    provide: SOCIAL_NETWORK_API_URL,
    useValue: environment.networkApi
  },
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
