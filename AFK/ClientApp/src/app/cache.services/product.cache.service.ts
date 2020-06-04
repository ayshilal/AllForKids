import { Injectable, OnDestroy, OnInit, Output, Input, EventEmitter } from "@angular/core";
import { Subscription } from "rxjs";
import { ProductService } from '../services/product.service';
import { Product, ProductEditModel, ProductSearchModel } from '../models/product';
import { Response } from '../models/response';
import { QueryOptions } from '../serializer/queryoptions.serializer';

@Injectable()
export class ProductCacheService implements OnInit, OnDestroy {
  product: Product;
  products: Product[];
  response: Response;   

  @Input() init: number = 0;
  @Output() onComplete = new EventEmitter<void>();
  @Output() talk: EventEmitter<string> = new EventEmitter<string>();

  private countdownEndRef: Subscription = null;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.restartCountdown(this.init);
    this.countdownEndRef = this.productService.countdownEnd$.subscribe(() => {
      this.onComplete.emit();
    });
  }

  ngOnDestroy() {
    this.productService.destroy();
  }     
  talkBack2(say: string) {
    this.talk.emit(say);
  }
  sayComplete() {

  }
  data: any;

  async getProducts(queryOptions: QueryOptions<ProductSearchModel>): Promise<Response> {
    if (!this.products) {
      await this.productService.getResponseList().toPromise()
        .then(
          item => { this.response = item; },
          msg => {
           // reject(msg);
          }
      );
    }
    return this.response;
  }
}
