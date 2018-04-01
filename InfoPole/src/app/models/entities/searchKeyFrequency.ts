import { IIdentifiable } from "../interfaces/IIdentifiable";

export class SearchKeyFrequency implements IIdentifiable{
    id: number;
    searchKeyId: number;
    searchEngineId: number;
    frequency: number;
    timeStamp: Date;
}