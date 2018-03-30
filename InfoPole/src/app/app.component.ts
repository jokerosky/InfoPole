import { Component, Inject } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { MatSnackBar, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

import {Endpoints} from './enums/Endpoints';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'app';
  baseUrl:string;

  constructor(
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    public snackBar: MatSnackBar
  ){
    this.baseUrl = baseUrl;
  }

  refreshServerCache(){
    var url = Endpoints.api.main.refreshCache;
    this.http.post(this.baseUrl + url,{})
            .subscribe((resp:any)=>{
                this.snackBar.open(`Cache refreshed timing [${resp.elapsedTime}] `, "Close",{
                  verticalPosition: 'top',
                  panelClass:['bg-light', 'text-secondary'],
                });
            },
            (err)=>{
                this.snackBar.open(err.message, "Close",{
                    verticalPosition: 'top',
                    panelClass:'bg-warning',
                  });
            })
  }
}
