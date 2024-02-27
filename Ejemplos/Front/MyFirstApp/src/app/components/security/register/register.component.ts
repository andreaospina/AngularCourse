import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  registerForm: FormGroup;
  /**
   *
   */
  constructor(fb: FormBuilder) {
    this.registerForm = fb.group({
      name: ["", Validators.required],
      lastName: ["", Validators.required],
      email: ["", Validators.required],
      password: ["", [Validators.required, Validators.minLength(4), Validators.maxLength(16)]],
      repeatPassword: ["", Validators.required],
    },{validator: this.checkPassword} )
  }

  checkPassword(group: FormGroup): any{
    const pass = group.value.password;
    const repeatPass = group.value.repeatPassword;
    return pass == repeatPass ? null : {passwordDifferent: true};
  }

  submit():void{
    console.log(this.registerForm);
  }
}
