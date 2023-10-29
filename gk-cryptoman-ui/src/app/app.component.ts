import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];
    errorMessage: any;

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('https://localhost:58849/Ping').subscribe(result => {
      this.forecasts = result;
    }, error => this.errorMessage = error.Messages);
  }

  title = 'gk-cryptoman-ui';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
