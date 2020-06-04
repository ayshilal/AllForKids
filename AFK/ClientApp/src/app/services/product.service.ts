import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Service } from './service';
import { Product, ProductEditModel, ProductSearchModel } from '../models/product';
import { ResponseSerializer } from '../serializer/response.serializer';

@Injectable()
export class ProductService extends Service<Product, ProductEditModel, ProductSearchModel> {
  constructor(httpClient: HttpClient) {
    super(httpClient, new ResponseSerializer(), 'Product');
  }
}
