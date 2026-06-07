import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  private apiUrl = `${environment.apiUrl}/api/transactions`;

  constructor(private http: HttpClient) {}

  getTransactions() {
    return this.http.get(this.apiUrl);
  }
}