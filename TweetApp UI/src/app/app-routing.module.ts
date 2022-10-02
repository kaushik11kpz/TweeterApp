import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth-guard';
import { ErrorComponent } from './error/error.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './register/reset-password/reset-password.component';
import { EditTweetComponent } from './tweet/edit-tweet/edit-tweet.component';
import { MyTweetsComponent } from './tweet/my-tweets/my-tweets.component';
import { ReplyTweetComponent } from './tweet/reply-tweet/reply-tweet.component';
import { TweetComponent } from './tweet/tweet.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path: '', redirectTo: 'tweetapp', pathMatch: "full"},
  {path: 'tweetapp/home', component: HomeComponent, children: [
    {path: 'tweets/reply/:id', component: ReplyTweetComponent},
    {path: 'tweets/edit/:id', component: EditTweetComponent},
    {path: 'users', component: UserComponent},
    {path: 'mytweets/user/:id', component: MyTweetsComponent},
    {path: 'my-profile/:id', component: ProfileComponent},
    {path: 'tweets', component: TweetComponent},
    {path: '', redirectTo: 'tweets',pathMatch: 'full'},
  ], canActivate:[AuthGuard]},
  {path: 'tweetapp', component: RegisterComponent},
  {path: 'tweetapp/reset-password', component: ResetPasswordComponent},
  {path: '**', component: ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
