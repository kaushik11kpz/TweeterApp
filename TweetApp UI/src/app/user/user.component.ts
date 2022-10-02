import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from './user.model';
import { UserService } from './user.service';
import { ViewUser } from './view-user.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit, OnDestroy {
  users: ViewUser[];
  allUserSubscription : Subscription;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers();
    this.allUserSubscription = this.userService.allUsers.subscribe((users) => {
      this.users = users;
      console.log(users);
    });
  }

  ngOnDestroy(){
    this.allUserSubscription.unsubscribe();
  }

}
