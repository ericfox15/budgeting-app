import { Component, OnInit } from '@angular/core';
import { TransactionsService } from './transactions.service';
@Component({
  selector: 'app-transactions',
  imports: [],
  templateUrl: './transactions.html',
  styleUrl: './transactions.css',
})
export class Transactions implements OnInit {

transactions: any[] = [];

constructor(private transactionsService: TransactionsService) {}

ngOnInit(): void {
  this.transactionsService.getTransactions().subscribe((data: any) => {
    this.transactions = data;
    console.log(this.transactions);
  });
}
}



