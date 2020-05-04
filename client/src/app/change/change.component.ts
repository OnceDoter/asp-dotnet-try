import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-change',
  templateUrl: './change.component.html',
  styleUrls: ['./change.component.css']
})
export class ChangeComponent implements OnInit {
  changeForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.changeForm = this.fb.group({
      'username': ['', [Validators.required]],
      'email': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
  }
  register() {
    console.log(this.changeForm.value)
    this.authService.register(this.changeForm.value).subscribe(data => {
      console.log(data)
    })
  }
  get username() {
    return this.changeForm.get('username');
  }
  get email() {
    return this.changeForm.get('email');
  }
  get password() {
    return this.changeForm.get('password');
  }
}

