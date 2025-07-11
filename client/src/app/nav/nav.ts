import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
 accountService = inject(AccountService);
 private router = inject(Router)
 private toastr = inject(ToastrService);
 model: any = {};

 login(){
  this.accountService.login(this.model).subscribe({
    next: _ => {
      this.router.navigateByUrl('/members')
    },
    error: error => this.toastr.error(error.error)
  })
 }
 logout() {
  this.accountService.logout();
  this.router.navigateByUrl('/');
 }
}
