import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisciplinesTableComponent } from './components/disciplines-table/disciplines-table.component';
import { ProfessorsTableComponent } from './components/professors-table/professors-table.component';
import { StudentsTableComponent } from './components/students-table/students-table.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'students',
    pathMatch: 'full',
  },
  {
    path: 'students',
    component: StudentsTableComponent,
  },
  {
    path: 'professors',
    component: ProfessorsTableComponent,
  },
  {
    path: 'disciplines',
    component: DisciplinesTableComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
