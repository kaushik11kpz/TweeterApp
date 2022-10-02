import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Tweet } from './tweet.model';
import { TweetService } from './tweet.service';

@Component({
  selector: 'app-tweet',
  templateUrl: './tweet.component.html',
  styleUrls: ['./tweet.component.css']
})
export class TweetComponent implements OnInit, OnDestroy {
  tweets: Tweet[];
  private allTweets: Subscription;
  constructor(private tweetService: TweetService) { }

  ngOnInit(): void {
    this.tweetService.getAllTweets();
     this.allTweets = this.tweetService.allTweets.subscribe((value: Tweet[]) => {
      this.tweets = value;
     });
  }

  ngOnDestroy(): void {
      this.allTweets.unsubscribe();
  }
}
