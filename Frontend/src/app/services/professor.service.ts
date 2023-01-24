import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProfessorService {
  constructor(private httpClient: HttpClient) {}

  createProfessor(professor: any) {
    return this.httpClient.post(
      `${environment.apiUrl}/api/professors/create`,
      professor
    );
  }

  getProfessors(): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}/api/professors/get-all`);
  }

  updateProfessor(id: string, professor: any) {
    return this.httpClient.put(
      `${environment.apiUrl}/api/professors/update/${id}`,
      professor
    );
  }

  deleteProfessor(id: string): Observable<any> {
    return this.httpClient.delete(
      `${environment.apiUrl}/api/professors/delete/${id}`
    );
  }
}
