import { IIdentifiable } from "../interfaces/IIdentifiable";

export class Tag implements IIdentifiable{
    id:number;
    word: string;

    markupTagId: number;
}