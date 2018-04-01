import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Endpoints } from '../enums/Endpoints';
import { MatSnackBar, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MarkupTag } from '../models/entities/MarkUpTag';
import { MarkUpTagServcie } from '../services/markupTagService';
import { Tag } from '../models/entities/Tag';

@Component({
    selector: 'markup-tags',
    templateUrl: '../templates/markupTags.cmpnt.html',
})
export class MakrUpTagsComponent implements OnInit {
    file: File;
    markupTags: MarkupTag[];
    tags: Tag[];

    selectedMarkupTagId: number;


    constructor(
        private mtagSvc: MarkUpTagServcie,
        public snackBar: MatSnackBar
    ) {
        this.file = null;
        this.markupTags = [];
        this.tags = [];
    }

    ngOnInit(): void {
        this.refreshMarkupTags();
    }

    refreshMarkupTags() {
        let url = Endpoints.api.markupTags.getList;
        this.mtagSvc.getMarkupTags()
            .subscribe((resp: MarkupTag[]) => {
                this.markupTags = resp;
            },
                (err) => {
                    this.snackBar.open(err.message, "Close", {
                        verticalPosition: 'top',
                        panelClass: ['bg-danger', 'text-white'],
                    });
                })
    }

    filesChanged(event) {
        this.file = event.target.files[0];
    }

    clearFiles() {
        this.file = null;
    }

    mtagChanged(e) {
        this.mtagSvc.getTagsForMarkupTag(e.value)
            .subscribe(
                (tags:Tag[]) => {
                    this.tags = tags;
            },
                (err) => { 
                    this.snackBar.open(err.message, "Close", {
                        verticalPosition: 'top',
                        panelClass: ['bg-danger', 'text-white'],
                    });
                })
    }

    onSubmit() {
        if (!this.file) {
            return false;
        }

        const formData: FormData = new FormData();
        formData.append('fileItem', this.file, this.file.name);

        this.mtagSvc.uploadMarkupTagsFile(formData)
            .subscribe((resp: any) => {
                this.snackBar.open('File uploaded', ':)', {
                    verticalPosition: 'top',
                    duration: 3000
                });

                this.refreshMarkupTags();
            },
                (err) => {
                    this.snackBar.open(err.message, ':)', {
                        verticalPosition: 'top',
                        panelClass: ['bg-danger', 'text-white']
                    });
                });
    }
}
