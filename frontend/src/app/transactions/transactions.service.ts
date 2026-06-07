import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  private apiUrl = 'http://localhost:5078/api/transactions';

  constructor(private http: HttpClient) {}

  getTransactions() {
    return this.http.get(this.apiUrl);
  }
}