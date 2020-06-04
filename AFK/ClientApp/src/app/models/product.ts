import {Response, ResponseEditModel, ResponseSearchModel } from './response';

export class Product extends Response{
    id: number;
    name: string;
    slug: string;
}
export class ProductEditModel extends ResponseEditModel{
    id: number;
    name:string;
    slug:string;
}
export class ProductSearchModel extends ResponseSearchModel{
    id: number;
    name: string;
    slug: string;
}