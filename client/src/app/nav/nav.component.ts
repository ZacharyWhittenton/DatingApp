import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
<<<<<<< HEAD
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
=======
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
<<<<<<< HEAD

  constructor(public accountService: AccountService) {}

  ngOnInit(): void {

=======
  loggedIn = false;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountService.currentUsers$.subscribe({
      next: user => this.loggedIn = !!user, // if we have a user it will return true if not false
      error: error => console.log(error)
    })
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
<<<<<<< HEAD
=======
        this.loggedIn = true;
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd
      },
      error: error => console.log(error)
    })
  }

  logout(){
    this.accountService.logout();
<<<<<<< HEAD
=======
    this.loggedIn =false;
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd
  }
}
