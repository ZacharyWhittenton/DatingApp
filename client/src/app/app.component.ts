import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
<<<<<<< HEAD
  title = 'Dating app';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {

    this.setCurrentUser();
  }



=======
  title = 'Portal app';
  users: any; // turns off type script

  constructor(private http: HttpClient, private accountService: AccountService) {}

  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({ // REQUEST TO HTTP SERVER
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }

>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd
  setCurrentUser() {
    const userString = localStorage.getItem('user')
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
