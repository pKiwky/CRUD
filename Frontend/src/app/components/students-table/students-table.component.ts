import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../../services/student.service';
import { DisciplineService } from 'src/app/services/discipline.service';
import { ClassbookService } from 'src/app/services/classbook.service';

@Component({
  selector: 'app-students-table',
  templateUrl: './students-table.component.html',
  styleUrls: ['./students-table.component.scss'],
})
export class StudentsTableComponent implements OnInit {
  students: any[] = [];
  studentGrades: any[] = [];
  disciplines: any[] = [];

  formData = new FormGroup({
    id: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    department: new FormControl(''),
    sex: new FormControl(''),
  });
  formDataGrade = new FormGroup({
    id: new FormControl(''),
    studentId: new FormControl(''),
    discipline: new FormControl(''),
    grade: new FormControl(''),
  });

  display: boolean = false;
  displayGrade: boolean = false;
  add: boolean = false;

  constructor(
    private studentService: StudentService,
    private disciplineService: DisciplineService,
    private classbookService: ClassbookService,
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

  getGrades(id: string) {
    this.classbookService.getStudentGrades(id).subscribe((resp) => {
      this.studentGrades = resp.result;

      this.studentGrades.forEach(element => {
        element.disciplineName = this.disciplines.find(d => d.id === element.disciplineId).name;
      })
    });
  }

  displayModal(student: any = null) {
    this.display = true;
    this.add = student === null;

    // Add
    if (student === null) {
      this.formData.reset();
    }
    // Edit
    else {
      this.formData.setValue({
        id: student.id,
        firstName: student.firstName,
        lastName: student.lastName,
        department: student.department,
        sex: student.sex,
      });
    }
  }

  displayGradeModal(student: any) {
    this.displayGrade = true;

    this.disciplineService.getDisciplines().subscribe((resp) => {
      this.disciplines = resp.result;
      this.getGrades(student.id);
    });

   this.formDataGrade.patchValue({
    studentId: student.id,
   })
  }

  addStudent() {
    this.studentService.createStudent(this.formData.value).subscribe({
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

    this.display = false;
  }

  addGrade() {
    this.classbookService.createStudentGrade({
      disciplineId: (this.formDataGrade.value.discipline as any).id,
      studentId: this.formDataGrade.value.studentId,
      grade: this.formDataGrade.value.grade,
    }).subscribe({
      next: (resp) => {
        this.toastrService.success('Student grade was added successfully.');
        this.getGrades(this.formDataGrade.value.studentId!);
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

  editStudent() {
    const id = this.formData.value.id;
    if (!id) {
      return;
    }

    this.studentService
      .updateStudent(id, {
        firstName: this.formData.value.firstName,
        lastName: this.formData.value.lastName,
        department: this.formData.value.department,
        sex: this.formData.value.sex,
      })
      .subscribe({
        next: (resp) => {
          this.toastrService.success('Student was updated successfully.');
          this.getStudents();
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

  deleteStudent(id: string) {
    this.studentService.deleteStudent(id).subscribe({
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

  deleteGrade(studentGrade: any) {
    this.classbookService.deleteGrade(studentGrade.id).subscribe({
      next: (resp) => {
        this.toastrService.success('Student grade was deleted successfully.');
        this.getGrades(studentGrade.studentId);
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
