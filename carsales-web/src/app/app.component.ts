import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'carsales-web';
  todaydate: any;

  constructor() {}

  ngOnInit() {
    // this.todaydate = this.vehicleService.getVechicles();
  }

  onClick() {}
}
