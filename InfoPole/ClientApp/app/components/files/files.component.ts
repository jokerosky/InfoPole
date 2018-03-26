import { Component, Inject,  } from '@angular/core';
import { Http, Response} from '@angular/http';

@Component({
    selector: 'files',
    templateUrl: './files.component.html'
})
export class FilesComponent {
    baseUrl: string;
    files: File[];

    constructor(
        private http: Http,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
        this.files = [];
    }

    public selectFiles(event: any) {
        this.files = [];
        for (let i = 0; i < (event.target.files as FileList).length; i++) {
            this.files.push((event.target.files[i] as File));
        }
    }

    public formSubmit(data: any) {
        debugger;
        if(this.files.length<1){
            return false;
        }

        let apiEndpoint = `${this.baseUrl}api/files/`
        const formData: FormData = new FormData();

        this.files.forEach(f => { formData.append('fileItem', f, f.name); })
        
        return this.http.post(apiEndpoint, formData).subscribe((resp:Response)=>{
            debugger;
            let bytes = resp.totalBytes;

        },
        (err)=>{
            debugger;
        });

    }
}
