import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule }   from '@angular/forms';


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
    BrowserModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'files', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'files', component: FilesComponent },
      { path: '**', redirectTo: 'home' }
  ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
