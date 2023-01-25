import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ClassbookService {
  constructor(private httpClient: HttpClient) {}

  createStudentGrade(studentGrade: any): Observable<any> {
    return this.httpClient.post(`${environment.apiUrl}/api/classbook/create-grade`, studentGrade);
  }

  getStudentGrades(id: string): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}/api/classbook/get-grades/${id}`);
  }

  deleteGrade(id: string): Observable<any> {
    return this.httpClient.delete(`${environment.apiUrl}/api/classbook/delete-grade/${id}`);
  }
}
