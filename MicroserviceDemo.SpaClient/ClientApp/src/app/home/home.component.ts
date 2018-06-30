import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  message: string = "Hit the button to get a message";

  constructor(private oauthService: OAuthService,
    private httpClient: HttpClient) {
  }

  public login() {
    this.oauthService.initImplicitFlow();
  }

  public getMessage() {
    let headers = new HttpHeaders({
      "Authorization": "Bearer " + this.oauthService.getAccessToken()
    });

    this.httpClient.get<string>("http://localhost:5002/api/hello/message",
      {
        headers: headers,
        responseType: 'text' as 'json'
      })
      .pipe(
        tap(result => this.message = result.toString()),
        catchError(err => {
          this.message = err.message;
          return throwError("Request error");
        })
      )
      .subscribe();
  }
}
