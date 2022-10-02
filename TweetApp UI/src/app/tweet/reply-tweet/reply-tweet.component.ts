import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Reply } from '../reply.model';
import { Tweet } from '../tweet.model';
import { TweetService } from '../tweet.service';

@Component({
  selector: 'app-reply-tweet',
  templateUrl: './reply-tweet.component.html',
  styleUrls: ['./reply-tweet.component.css']
})
export class ReplyTweetComponent implements OnInit, OnDestroy {
  @ViewChild('f') form:NgForm;
  private isChanges: Subscription;
  tweet: Tweet;
  id: string;
  reply: boolean;
  constructor(private tweetService: TweetService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (param: Params) =>{
        this.id = param['id'];
        this.tweetService.getTweetById(this.id);
      }
    );

    this.isChanges =  this.tweetService.tweetChanged.subscribe((tweetUpdated) => {
      this.tweet = tweetUpdated;
      this.reply = tweetUpdated != undefined ? tweetUpdated.replies.length > 0 : false;
    });
  }

  onReply(){
    const value = this.form.value;
    const reply = new Reply(value.replyText);
    this.tweetService.addReply(reply, this.id);
    this.form.reset();
  }


  ngOnDestroy(): void {
      this.isChanges.unsubscribe();
  }

}
