import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Endpoints } from '../enums/Endpoints';
import { Observable } from "rxjs/Observable";

@Injectable()
export class MarkUpTagServcie{
    baseUrl: string;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string,
    ){
        this.baseUrl = baseUrl;
    }

    uploadMarkupTagsFile(formData:FormData):Observable<Object> {
        var endpoint = Endpoints.baseUrl + Endpoints.api.markupTags.postFile;
        
        return this.http.post(
            endpoint,
            formData
        )
    }

    getMarkupTags(){
        var endpoint = Endpoints.baseUrl + Endpoints.api.markupTags.getList;
        
        return this.http.get(
            endpoint
        )
    }

    updateMarkupTag(){

    }

    deleteMarkupTag(){

    }

    getTagsForMarkupTag(mtagId){
        var endpoint = Endpoints.baseUrl + Endpoints.api.tags.get;
        
        return this.http.get(
            endpoint,
            {
                params:{
                    markupTagId: mtagId
                }
            }
        );
    }

    addTagForMarkupTag(){

    }

    updateTagForMarkupTag(){

    }

    deleteTagForMarkupTag(){

    }
}