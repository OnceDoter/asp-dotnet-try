import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import {Router} from '@angular/router';
import {LoginComponent} from '../login/login.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [LoginComponent]
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private  router: Router,
    private loginComponent: LoginComponent) {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.router.navigate(['sucsess']).then(this.loginComponent.setdata);
    });
  }

  get username() {
    localStorage.setItem('username', this.registerForm.get('username').value);
    return this.registerForm.get('username');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    localStorage.setItem('password', this.registerForm.get('password').value);
    return this.registerForm.get('password');
  }

}
