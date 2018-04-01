import { IIdentifiable } from "../interfaces/IIdentifiable";

export class DataFile implements IIdentifiable{
    id: number;
    name: string;
    uploaded: Date;
    searchEngineId: number;

    processingDuration: string;
    recordsCount: number;
}