import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-sucsess',
  templateUrl: './sucsess.component.html',
  styleUrls: ['./sucsess.component.css'],
})
export class SucsessComponent implements OnInit {

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    let time = 3000;
    time += new Date().getTime();
    while (new Date().getTime() < time) { }
    this.router.navigate(['login'])
      .then(this.authService.sendEmail);
  }
}
