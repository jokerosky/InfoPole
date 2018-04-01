import { IIdentifiable } from "../interfaces/IIdentifiable";

export class UrlItem implements IIdentifiable{
    id: number;
    url: string;
    domain: string;
}