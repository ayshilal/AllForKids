import { Component,OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Service } from '../../../../services/service';
import { ResponseSerializer } from '../../../../serializer/response.serializer';
import { ProductCacheService } from 'src/app/cache.services/product.cache.service';
import { ProductService } from 'src/app/services/product.service';
import { ProductSearchModel } from 'src/app/models/product';
import { QueryOptions } from 'src/app/serializer/queryoptions.serializer';
import { ProductSidebarComponent } from '../../../shop/components/product-sidebar/product-sidebar.component';
@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./page-login.component.scss'],
    providers: [ProductCacheService]
})
export class PageLoginComponent implements OnInit
 {
    form: FormGroup;
    loading = false;
    submitted = false;
    productSearchModel: ProductSearchModel;
    returnUrl: string;
    cdata: any;
    constructor( private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private productService: ProductService,
        private productCache: ProductCacheService,
        private queryOptions: QueryOptions<ProductSearchModel>
        ) { 
            queryOptions.page = 1;
            queryOptions.pageSize = 10000;
            queryOptions.search = this.productSearchModel;
        }
        ngOnInit() {
            this.productSearchModel = new ProductSearchModel();

            this.form = this.formBuilder.group({
                username: ['', Validators.required],
                password: ['', Validators.required]
            });
    
            // get return url from route parameters or default to '/'
            this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        }
        get f() { return this.form.controls; }
        onSubmit() {
            this.submitted = true;
    
            // reset alerts on submit
    
            // stop here if form is invalid
            if (this.form.invalid) {
                return;
            }
    
            this.loading = true;
            this.queryOptions.search = this.productSearchModel;
            this.productCache.getProducts(this.queryOptions)
            .then(
                list => {
                this.cdata = list;
                },
                msg => {
                
                }
            );
        }
}
