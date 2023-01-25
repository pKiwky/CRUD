import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DisciplineService } from 'src/app/services/discipline.service';

@Component({
  selector: 'app-disciplines-table',
  templateUrl: './disciplines-table.component.html',
  styleUrls: ['./disciplines-table.component.scss'],
})
export class DisciplinesTableComponent implements OnInit {
  disciplines: any[] = [];
  formData = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    courseHours: new FormControl(''),
    seminaryHours: new FormControl(''),
    laboratoryHours: new FormControl(''),
    credits: new FormControl(''),
  });
  display: boolean = false;
  add: boolean = false;

  constructor(
    private disciplineService: DisciplineService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getDisciplines();
  }

  getDisciplines() {
    this.disciplineService.getDisciplines().subscribe((resp) => {
      this.disciplines = resp.result;
    });
  }

  displayModal(discipline: any = null) {
    this.display = true;
    this.add = discipline === null;

    // Add
    if (discipline === null) {
      this.formData.reset();
    }
    // Edit
    else {
      this.formData.setValue({
        id: discipline.id,
        name: discipline.name,
        courseHours: discipline.courseHours,
        laboratoryHours: discipline.laboratoryHours,
        seminaryHours: discipline.seminaryHours,
        credits: discipline.credits,
      });
    }
  }

  addDiscipline() {
    this.disciplineService.createDiscipline(this.formData.value).subscribe({
      next: (resp) => {
        this.toastrService.success('Discipline was added successfully.');
        this.getDisciplines();
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

  editDiscipline() {
    const id = this.formData.value.id;
    if (!id) {
      return;
    }

    this.disciplineService
      .updateDiscipline(id, {
        name: this.formData.value.name,
        courseHours: this.formData.value.courseHours,
        laboratoryHours: this.formData.value.laboratoryHours,
        seminaryHours: this.formData.value.seminaryHours,
        credits: this.formData.value.credits,
      })
      .subscribe({
        next: (resp) => {
          this.toastrService.success('Discipline was updated successfully.');
          this.getDisciplines();
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

  deleteDiscipline(id: any) {
    this.disciplineService.deleteDiscipline(id).subscribe({
      next: (resp) => {
        this.toastrService.success('Discipline was deleted successfully.');
        this.getDisciplines();
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
