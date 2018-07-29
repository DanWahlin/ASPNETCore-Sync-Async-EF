import { Component, OnInit } from '@angular/core';
import { DataService } from 'app/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  customers: any = [];

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.dataService.getCustomers()
        .subscribe(customers => this.customers = customers);
  }
}
