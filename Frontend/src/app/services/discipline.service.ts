import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DisciplineService {
  constructor(private httpClient: HttpClient) {}

  createDiscipline(discipline: any) {
    return this.httpClient.post(
      `${environment.apiUrl}/api/disciplines/create`,
      discipline
    );
  }

  getDisciplines(): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}/api/disciplines/get-all`);
  }

  updateDiscipline(id: string, discipline: any) {
    return this.httpClient.put(
      `${environment.apiUrl}/api/disciplines/update/${id}`,
      discipline
    );
  }

  deleteDiscipline(id: string): Observable<any> {
    return this.httpClient.delete(
      `${environment.apiUrl}/api/disciplines/delete/${id}`
    );
  }
}
