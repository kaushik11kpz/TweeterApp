import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../auth.service';
import { ViewUser } from '../user/view-user.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {
  menuOptions = [{icon: "home", labelName: "Home"}, 
  {icon: "search", labelName: "Search"},
  {icon: "notifications_none", labelName: "Notifications"},
  {icon: "mail_outline", labelName: "Messages"},
  {icon: "bookmark_border", labelName: "Bookmarks"},
  {icon: "list_alt", labelName: "Lists"},
  {icon: "perm_identity", labelName: "Profiles"},
  {icon: "more_horiz", labelName: "More"}
]
  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }
  user : ViewUser | null;
  userId: string | null;
  authSubscription : Subscription;
  ngOnInit(): void {
    this.authSubscription = this.authService.userDetail.subscribe((user) => {
      this.user = user;
    })
    this.userId = localStorage.getItem('user');
  }

  onSelect(value: string){
    this.authService.selectedValue.emit(value);
  }

  onLogout(){
    this.authService.logout();
    this.router.navigate(['tweetapp']);
  }

  ngOnDestroy(){
    this.authSubscription.unsubscribe();
  }

}
