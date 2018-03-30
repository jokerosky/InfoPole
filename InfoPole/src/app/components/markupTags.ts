import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import {Endpoints} from '../enums/Endpoints';
import { MatSnackBar, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

@Component({
    selector: 'markup-tags',
    templateUrl: '../templates/markupTags.cmpnt.html',
})
export class MakrUpTagsComponent implements OnInit{
    baseUrl: string;
    file: File;
    markupTags: any[];

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string,
        public snackBar: MatSnackBar
    ) {
        this.baseUrl = baseUrl;
        this.file = null;
        this.markupTags = ['a','b','c','d'];
    }

    ngOnInit(): void {
        this.refreshMarkupTags();    
    }

    refreshMarkupTags(){
        let url = Endpoints.api.markupTags.getList;
        this.http.get(this.baseUrl + url)
            .subscribe((resp:any)=>{
                this.markupTags = resp;
            },
            (err)=>{
                this.snackBar.open(err.message, "Close",{
                    verticalPosition: 'top',
                    panelClass:'bg-warning',
                  });
            })
    }

    filesChanged(event) {
        this.file = event.target.files[0];
    }

    clearFiles(){
        this.file = null;
    }

    onSubmit(){
        if(!this.file){
            return false;
        }
        debugger;
        let apiEndpoint = `${this.baseUrl}MarkupTag/File`;

        const formData: FormData = new FormData();
        formData.append('fileItem', this.file, this.file.name);
        
        
        this.http.post(
                apiEndpoint,
                formData
            ).subscribe((resp:any)=>{
            debugger;
            let bytes = resp;
        },
        (err)=>{
            debugger;
        });
    }
}
