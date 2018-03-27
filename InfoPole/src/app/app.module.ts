import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home.cmpnt';
import { FilesComponent } from './components/files.cmpnt';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FilesComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'files', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'files', component: FilesComponent },
      { path: '**', redirectTo: 'home' }
  ])
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return 'http://localhost:50197/';
    //return document.getElementsByTagName('base')[0].href;
}