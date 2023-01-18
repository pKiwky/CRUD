import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-students-table',
  templateUrl: './students-table.component.html',
  styleUrls: ['./students-table.component.scss'],
})
export class StudentsTableComponent implements OnInit {
  students: any[] = [];
  formData = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    department: new FormControl(''),
    sex: new FormControl(''),
  });
  showModal = false;

  constructor(
    private studentService: StudentService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents() {
    this.studentService.getStudents().subscribe((data) => {
      this.students = data.result;
    });
  }

  delete(id: any) {
    this.studentService.delete(id).subscribe({
      next: (resp) => {
        this.toastrService.success('Student was deleted successfully.');
        this.getStudents();
      },
      error: (e) => {
        e = e.error;

        if (e.errors != null) {
          this.toastrService.error(e.errors[0].message);
        }
      },
    });
  }

  add() {
    this.studentService.create(this.formData.value).subscribe({
      next: (resp) => {
        this.toastrService.success('Student was added successfully.');
        this.getStudents();
      },
      error: (e) => {
        e = e.error;

        if (e.errors != null) {
          this.toastrService.error(e.errors[0].message);
        }
      },
    });

    this.showModal = false;
    this.formData.reset();
  }

  showAdd() {
    this.showModal = true;
  }
}
