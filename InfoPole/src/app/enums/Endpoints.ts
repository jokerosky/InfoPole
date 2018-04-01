


export class Endpoints {

    
    public static baseUrl ="http://localhost:50378/";
    public static ui = {}
    public static api = {
        main:{
            refreshCache:'refresh'
        },
        tags:{
            get:'Tag'
        },
        markupTags:{
            getList: "MarkupTag",
            postFile:"MarkupTag/File"
        },
        dataFiles:{
            get:'files'
        }
    }
}