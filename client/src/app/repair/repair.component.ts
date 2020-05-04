import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-repair',
  templateUrl: './repair.component.html',
  styleUrls: ['./repair.component.css']
})
export class RepairComponent implements OnInit {
  repairForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.repairForm = this.fb.group({
      'username': ['', [Validators.required]],
      'email': ['', [Validators.required]]
    })
  }
  ngOnInit(): void {
  }

  repair() {
    
  } 
}
