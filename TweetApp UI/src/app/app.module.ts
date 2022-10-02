import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { TweetComponent } from './tweet/tweet.component';
import { UserComponent } from './user/user.component';
import { TweetItemsComponent } from './tweet/tweet-items/tweet-items.component';
import { PostTweetComponent } from './tweet/post-tweet/post-tweet.component';
import { TweetService } from './tweet/tweet.service';
import { AuthService } from './auth.service';
import { UserService } from './user/user.service';
import { ReplyTweetComponent } from './tweet/reply-tweet/reply-tweet.component';
import { EditTweetComponent } from './tweet/edit-tweet/edit-tweet.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { AuthGuard } from './auth-guard';
import { MyTweetsComponent } from './tweet/my-tweets/my-tweets.component';
import { ProfileComponent } from './profile/profile.component';
import { ResetPasswordComponent } from './register/reset-password/reset-password.component';
import { ErrorComponent } from './error/error.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    HeaderComponent,
    TweetComponent,
    UserComponent,
    TweetItemsComponent,
    PostTweetComponent,
    ReplyTweetComponent,
    EditTweetComponent,
    MyTweetsComponent,
    ProfileComponent,
    ResetPasswordComponent,
    ErrorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [HttpClientModule, AuthService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
