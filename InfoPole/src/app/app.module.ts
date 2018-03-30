import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import {MatSelectModule} from '@angular/material/select';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';


import { AppComponent } from './app.component';
import { HomeComponent } from './components/home.cmpnt';
import { FilesComponent } from './components/files.cmpnt';
import { MakrUpTagsComponent } from './components/markupTags';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FilesComponent,
    MakrUpTagsComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    MatInputModule,
    MatSelectModule,
    MatSnackBarModule,

    FormsModule,
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'files', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'files', component: FilesComponent },
      { path: 'markuptags', component: MakrUpTagsComponent },
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