import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProfessorService } from 'src/app/services/professor.service';

@Component({
  selector: 'app-professors-table',
  templateUrl: './professors-table.component.html',
  styleUrls: ['./professors-table.component.scss'],
})
export class ProfessorsTableComponent implements OnInit {
  professors: any[] = [];
  formData = new FormGroup({
    id: new FormControl(''),
    cnp: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    function: new FormControl(''),
    address: new FormControl(''),
    phone: new FormControl(''),
  });
  display: boolean = false;
  add: boolean = false;

  constructor(
    private professorService: ProfessorService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getProfessors();
  }

  getProfessors() {
    this.professorService.getProfessors().subscribe((data) => {
      this.professors = data.result;
    });
  }

  displayModal(professor: any = null) {
    this.display = true;
    this.add = professor === null;

    // Add
    if (professor === null) {
      this.formData.reset();
    }
    // Edit
    else {
      this.formData.setValue({
        id: professor.id,
        cnp: professor.cnp,
        firstName: professor.firstName,
        lastName: professor.lastName,
        function: professor.function,
        address: professor.address,
        phone: professor.phone,
      });
    }
  }

  addProfessor() {
    this.professorService.createProfessor(this.formData.value).subscribe({
      next: (resp) => {
        this.toastrService.success('Professor was added successfully.');
        this.getProfessors();
      },
      error: (e) => {
        e = e.error;

        if (e.errors != null) {
          this.toastrService.error(e.errors[0].message);
        }
      },
    });

    this.display = false;
  }

  editProfessor() {
    const id = this.formData.value.id;
    if (!id) {
      return;
    }

    this.professorService
      .updateProfessor(id, {
        cnp: this.formData.value.cnp,
        firstName: this.formData.value.firstName,
        lastName: this.formData.value.lastName,
        function: this.formData.value.function,
        address: this.formData.value.address,
        phone: this.formData.value.phone,
      })
      .subscribe({
        next: (resp) => {
          this.toastrService.success('Professor was updated successfully.');
          this.getProfessors();
        },
        error: (e) => {
          e = e.error;

          if (e.errors != null) {
            this.toastrService.error(e.errors[0].message);
          }
        },
      });

    this.display = false;
  }

  deleteProfessor(id: any) {
    this.professorService.deleteProfessor(id).subscribe({
      next: (resp) => {
        this.toastrService.success('Professor was deleted successfully.');
        this.getProfessors();
      },
      error: (e) => {
        e = e.error;

        if (e.errors != null) {
          this.toastrService.error(e.errors[0].message);
        }
      },
    });
  }
}
