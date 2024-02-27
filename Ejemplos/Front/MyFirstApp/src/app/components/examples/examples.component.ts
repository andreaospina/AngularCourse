import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-examples',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './examples.component.html',
  styleUrl: './examples.component.css'
})
export class ExamplesComponent {

  title = 'MyFirstApp';
  myVar = "test";
  name = "Pedro";
  lastName = "Ospina";
  counter = 0;
  studentsList = [
    {"name":"pedro", "age": 23},
    {"name":"francisco", "age": 2},
    {"name":"carlos", "age": 14},
    {"name":"petardo", "age": 56}
  ];
  Show = true;
  
  IncreaseCounter():void{
    this.counter += 1;
  }
  Tooggle(): void{
    this.Show = !this.Show; // Assign the oposite value that the var has right now. 
  }
}
