import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Nav } from "./nav/nav";
import { AccountService } from './_services/account';
import { Home } from "./home/home";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Nav, Home],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{
    private accountService = inject(AccountService);
  
  
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }

}
