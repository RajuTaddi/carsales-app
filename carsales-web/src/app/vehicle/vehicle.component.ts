import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/services/config.service';
import { PATH_VEHICLE_DETAILS } from 'src/common/constats';
import * as _ from 'lodash';
import { VehicleDetail } from 'src/common/types';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { NotificationComponent } from '../notification/notification.component';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css'],
})
export class VehicleComponent implements OnInit {
  vehicleId: string;
  vehicle: VehicleDetail;
  features: any;
  images: string[];
  featuresGroup: any;
  panelOpenState: boolean = false;
  isLoading: boolean = true;
  constructor(
    private route: ActivatedRoute,
    private configService: ConfigService,
    private httpClient: HttpClient,
    public matDialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: any) => {
      this.getVehicleDetails(paramMap.params.id);
    });
  }

  getVehicleDetails(id: string) {
    const url =
      this.configService.config.vehicle_service.host +
      this.configService.config.vehicle_service.path[
        PATH_VEHICLE_DETAILS
      ].replace(':id', id);
    this.httpClient.get(url).subscribe(
      (response: any) => {
        this.vehicle = response;
        this.featuresGroup = _.groupBy(response.features, 'group');
        this.features = _.sortBy(Object.keys(this.featuresGroup));
        this.images = this.vehicle.photos;
        this.isLoading = false;
      },
      (error) => {
        this.showModel(error.message);
      }
    );
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
