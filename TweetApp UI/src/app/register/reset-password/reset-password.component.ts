import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  options = [
    {key: 1, value:"Favorite Movie"},
    {key: 2, value:"Favorite Color"},
    {key: 3, value:"Favorite Cuisine"},
    {key: 4, value:"Favorite Sport"}
  ]
  constructor(private authService: AuthService, private router: Router) { }
  isValid = false;
  emailId = '';
  isPasswordResetSuccessfull = false;
  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    this.emailId = form.value.email;
    this.authService.SecurityCheckValidation(form.value.email, +form.value.question, form.value.answer).subscribe((res) => {
      this.isValid = res;
    });
  }

  onReset(form: NgForm){
    this.authService.resetPassword(this.emailId, form.value.password).subscribe((res) =>{
      if(res){
        this.isPasswordResetSuccessfull = true;
        setTimeout(() => {
          this.router.navigate(['tweetapp']);
        },2000);
      }
    });
  }
}
