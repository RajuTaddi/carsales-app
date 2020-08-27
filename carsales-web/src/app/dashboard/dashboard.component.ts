import { Component, OnInit } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/services/config.service';
import { PATH_VEHICLE_LIST } from 'src/common/constats';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NotificationComponent } from '../notification/notification.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  vehicles: any;
  title: string;
  year: string;
  hasError: boolean = false;
  isLoading: boolean = true;
  constructor(
    private configService: ConfigService,
    private httpClient: HttpClient,
    public matDialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.isLoading = true;
    this.getVechicles();
  }

  getVechicles() {
    const url =
      this.configService.config.vehicle_service.host +
      this.configService.config.vehicle_service.path[PATH_VEHICLE_LIST];
    this.httpClient.get(url).subscribe(
      (response: any) => {
        this.vehicles = response;
        this.isLoading = false;
      },
      (error) => {
        console.log(error);
        this.isLoading = false;
        this.hasError = true;
        console.log(error);

        this.showModel(error.message);
      }
    );
  }

  getTitle(title: string) {
    const titleArr = title.split(' ');
    this.title = titleArr[1] + ' ' + titleArr[2];
    this.year = titleArr[0];

    return this.title;
  }

  showModel(message) {
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = 'modal-component';
    dialogConfig.height = '200px';
    dialogConfig.width = '600px';
    dialogConfig.data = message;
    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(
      NotificationComponent,
      dialogConfig
    );
  }
}
