import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { DataFile } from '../models/entities/dataFile';
import { Endpoints } from '../enums/Endpoints';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'files',
    templateUrl: '../templates/files.cmpnt.html',
})
export class FilesComponent implements OnInit  {
    files: File[];
    baseUrl: string;
    dataFiles: DataFile[];
    searcherId: number;

    constructor(
        private http: HttpClient,
        public snackBar: MatSnackBar
    ) {
        this.files = [];
    }

    ngOnInit(): void {
        this.refreshLoadedFiles();
    }

    refreshLoadedFiles()
    {
        var endpoint = Endpoints.baseUrl + Endpoints.api.dataFiles.get;
        this.http.get(endpoint)
            .subscribe(
                (files:DataFile[])=>{
                    this.dataFiles = files;
                },
                (err)=>{

                }
            )
    }

    filesChanged(event) {
        this.files = event.target.files;
    }

    clearFiles(){
        this.files = [];
    }

    onSubmit(){
        if(this.files.length < 1){
            return false;
        }
        
        let apiEndpoint = Endpoints.baseUrl + `files?searcherId=${this.searcherId}`;

        const formData: FormData = new FormData();

        for (let i = 0; i < this.files.length; i++) {
            formData.append('fileItem'+i, this.files[i], this.files[i].name);
        }
        //this.files.forEach(f => { formData.append('fileItem', f, f.name); })
        
        this.http.post(
                apiEndpoint,
                formData
            ).subscribe((resp:DataFile[])=>{
                this.dataFiles = resp;
        },
        (err)=>{
            debugger;
            this.snackBar.open(err.error, "Close", {
                verticalPosition: 'top',
                panelClass: ['bg-danger', 'text-white'],
            });
        });
    }
}
