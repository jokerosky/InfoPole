import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
    selector: 'files',
    templateUrl: '../templates/files.cmpnt.html',
})
export class FilesComponent {
    files: File[];
    baseUrl: string;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
        this.files = [];
    }

    filesChanged(event) {
        this.files = [];
        for (let i = 0; i < event.target.files.length; i++) {
            this.files.push(event.target.files[i]);
        }
    }

    onSubmit(){
        if(this.files.length < 1){
            return false;
        }

        let apiEndpoint = `${this.baseUrl}api/files/`;
        let headers = new HttpHeaders();
        headers.append('Content-Type','multipart/form-data;');

        const formData: FormData = new FormData();

        this.files.forEach(f => { formData.append('fileItem', f, f.name); })
        
        return this.http.post(
                apiEndpoint,
                formData,
                {
                    headers
                }
            ).subscribe((resp:HttpResponse<any>)=>{
            debugger;
            let bytes = resp;

        },
        (err)=>{
            debugger;
        });
    }
}
