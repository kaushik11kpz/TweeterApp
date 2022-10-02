import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'tweet-app';
  textInput = '';
  isLoggedIn = false;
  userLogin : Subscription;
  constructor(private authService: AuthService){
  }

  ngOnInit(){
   
  }

  ngOnDestroy(){
    this.userLogin.unsubscribe();
  }

}
