import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Transactions } from './transactions/transactions.component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Transactions],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('budgeting-app');
}
