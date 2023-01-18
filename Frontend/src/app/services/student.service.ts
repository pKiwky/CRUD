import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  constructor(private httpClient: HttpClient) {}

  create(student: any) {
    return this.httpClient.post(`${environment.apiUrl}/api/students/create`, student);
  }

  getStudents(): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}/api/students/get-all`);
  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete(
      `${environment.apiUrl}/api/students/delete/${id}`
    );
  }
}
