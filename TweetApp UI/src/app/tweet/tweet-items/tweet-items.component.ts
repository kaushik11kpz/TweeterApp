import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { ViewUser } from 'src/app/user/view-user.model';
import { Reply } from '../reply.model';
import { Tweet } from '../tweet.model';
import { TweetService } from '../tweet.service';

@Component({
  selector: 'app-tweet-items',
  templateUrl: './tweet-items.component.html',
  styleUrls: ['./tweet-items.component.css']
})
export class TweetItemsComponent implements OnInit {
  @Input() tweet: Tweet;
  userId: string | null;
  constructor(private router: Router, private authService: AuthService, private tweetService: TweetService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('user');
  }

  onClick(){
    this.router.navigate(['tweetapp/reply']);
  }

  onDelete(tweetId: string){
    this.tweetService.deleteTweetFromHome(tweetId);
  }

  onLike(tweetId: string, userId: string){
    this.tweetService.likeOrDisLikeTweet(tweetId,userId);
  }

}
