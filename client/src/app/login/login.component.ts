import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
    console.log('init login component');
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(data => {
      this.authService.saveToken(data.token);
      this.router.navigate(['videos']).then(() => {
        console.log('succeed login');
      });
    });
  }

  register() {
    this.router.navigate(['register']).then(() => {
      console.log('navigate to register');
    });
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
  setdata(){
    this.loginForm.value.username = (localStorage.getItem('username'));
    this.loginForm.value.password = (localStorage.getItem('password'));
  }

}
