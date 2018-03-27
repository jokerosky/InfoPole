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
        this.files = event.target.files;
    }

    clearFiles(){
        this.files = [];
    }

    onSubmit(){
        if(this.files.length < 1){
            return false;
        }
        debugger;
        let apiEndpoint = `${this.baseUrl}files/`;

        const formData: FormData = new FormData();

        for (let i = 0; i < this.files.length; i++) {
            formData.append('fileItem'+i, this.files[i], this.files[i].name);
        }
        //this.files.forEach(f => { formData.append('fileItem', f, f.name); })
        
        return this.http.post(
                apiEndpoint,
                formData
            ).subscribe((resp:HttpResponse<any>)=>{
            debugger;
            let bytes = resp;

        },
        (err)=>{
            debugger;
        });
    }
}
