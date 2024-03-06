import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CreditHistory } from '../models/user-details';
import { ModalComponent } from '../app/modal/modal.component';
import { NgClass } from '@angular/common';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, ReactiveFormsModule, ModalComponent, NgClass],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent {
  creditScore!: number;
  creditRating!: string;
  isRed: boolean= false;
  isBlue: boolean= false;
  isGreen: boolean= false;
  isYellow: boolean= false;
  

  bvnForm: FormGroup = new FormGroup({
    bvn: new FormControl(''),
  });

  fetchedCreditHistory!: CreditHistory[];

  constructor(private assess: ApiService) {}
 

  chnageBg(creditRating: string){
    if (creditRating === "F") {
      this.isRed=true;
      this.isYellow=false
      this.isGreen=false;
      this.isBlue=false 
      console.log('Credit Rating:', creditRating);
  // Your existing logic...
  console.log('isRed:', this.isRed);
  console.log('isGreen:', this.isGreen);
  console.log('isBlue:', this.isBlue);
  console.log('isYellow:', this.isYellow);         

    } else if (creditRating === "C"){
      this.isRed=false;
      this.isYellow=false
      this.isGreen=false;
      this.isBlue=true
    }else if (creditRating === "B"){
      this.isRed=false;
      this.isYellow=true
      this.isGreen=false;
      this.isBlue=true
    }else if (creditRating === "A"){
      this.isRed=false;
      this.isYellow=false
      this.isGreen=true;
      this.isBlue=true
    }
  }
  onSubmit(): void {

    this.assess.assessCreditHistory(this.bvnForm.value).subscribe(
      (response) => {
        console.log(response);
        this.creditScore = response.data.predictedCreditScore;
        this.creditRating = response.data.creditRating;
        this.chnageBg(this.creditRating)
      },
      (error) => {
        console.error(error);
      }
    );

    this.assess.getAssessedCreditHistory(this.bvnForm.value).subscribe(
      (response)=>{
        console.log(response);

      },
      (error)=>{
        console.error(error);

      }
    )
  }

  // onGetAccess()

  openModal() {
    const modal = document.getElementById('static-modal');
    this.assess.getAssessedCreditHistory(this.bvnForm?.value).subscribe(
      (response) => {
        this.fetchedCreditHistory = response?.data;
        console.log(this.fetchedCreditHistory);
      },
      (error) => {
        console.error(error);
      }
    );

    if (modal) {
      modal.style.display = 'flex';
    }
  }
}
