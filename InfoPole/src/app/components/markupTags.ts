import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
    selector: 'markup-tags',
    templateUrl: '../templates/markupTags.cmpnt.html',
})
export class MakrUpTagsComponent {
    baseUrl: string;
    file: File;
    markupTags: any[];

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
        this.file = null;
        this.markupTags = ['a','b','c','d'];
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
            ).subscribe((resp:HttpResponse<any>)=>{
            debugger;
            let bytes = resp;
        },
        (err)=>{
            debugger;
        });
    }
}
