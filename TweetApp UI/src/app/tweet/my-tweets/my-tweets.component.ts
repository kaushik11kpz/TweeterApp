import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Tweet } from '../tweet.model';
import { TweetService } from '../tweet.service';

@Component({
  selector: 'app-my-tweets',
  templateUrl: './my-tweets.component.html',
  styleUrls: ['./my-tweets.component.css']
})
export class MyTweetsComponent implements OnInit, OnDestroy {
  tweets: Tweet[];
  tweetSubscription : Subscription;
  constructor(private tweetService: TweetService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((param) => {
      this.tweetService.getTweetByUserId(param['id']);
    });

    this.tweetSubscription =  this.tweetService.allTweets.subscribe((tweets) => {
      console.log(tweets);
      this.tweets = tweets;
    });
  }

  onDelete(tweetId: string, userId: string){
    this.tweetService.deleteTweetFromMyTweet(tweetId, userId);
  }

  onLike(tweetId: string, userId: string){
    this.tweetService.likeOrDisLikeTweet(tweetId,userId);
  }

  ngOnDestroy(){
    this.tweetSubscription.unsubscribe();
  }
}
