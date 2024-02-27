import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AnotherModel } from '../../../models/anotherModel';
import { User } from '../../../models/user';
import { LoadingComponent } from '../../shared/loading/loading.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, LoadingComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading: boolean = false;
  constructor( private fb: FormBuilder, private toastr: ToastrService, private router: Router) {
    this.loginForm = fb.group(
      {
        email: ['', [Validators.required]],
        password: ['', Validators.required]
      });
  }
 
  Save():void{
    const data = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password,
      test: "any random info"
    };

    const userData: User = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password,
      age: 2
      // test: "random info" // This gives me error in coding time
    };
    console.log(data);
    console.log(userData);
    this.showData(data);
    this.showData(userData);

    this.showUserData(data);
    this.showUserData(userData);

    const randomData: AnotherModel = {
      OneProperty: "some info",
      AnotherProperty: "more random info ..."
    };
    // this.showUserData(randomData); // This gives me error in coding time
    this.isLoading = true;
    setTimeout(() => {
      
      this.isLoading = false;
      if(userData.email == "Pedro"){
        this.router.navigate(["/admin/dashboard"]);
      }else{
        this.toastr.error('Invalid credentials', 'Error!');
        this.toastr.info('Some useful information', 'Information!');
        this.toastr.success('Saved correctly', 'Nice job!');
        this.toastr.warning('Invalid credentials', 'Warning!');
      }
    }, 3000);
    
  }

  showData(data: any){
    console.log(data.test);
    console.log(data.emial);
    console.log(data.pasword);
    console.log(data.whatever);
  }
  
  showUserData(userData: User){
    console.log(userData.email);
    console.log(userData.pasword);
    // console.log(userData.whatever); // Gives me error in coding time !!!
  }
}
