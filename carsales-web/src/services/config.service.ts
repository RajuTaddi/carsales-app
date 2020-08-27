import { Injectable } from '@angular/core';
import { AppConfig } from '../common/types';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  config: AppConfig;

  constructor() {
    if (!!environment) {
      this.config = environment;
    }
  }
}
