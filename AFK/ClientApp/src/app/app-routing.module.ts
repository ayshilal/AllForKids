import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { PageHomeOneComponent } from './pages/page-home-one/page-home-one.component';
import { PageHomeTwoComponent } from './pages/page-home-two/page-home-two.component';
import { RootComponent } from './components/root/root.component';


const routes: Routes = [
    // START / ONLY_FOR_DEMO_YOU_CAN_DELETE_IT
    {
        path: 'home-two',
        component: RootComponent,
        data: {
            headerLayout: 'compact'
        },
        children: [
            {
                path: '',
                component: PageHomeTwoComponent
            }
        ],
    },
    // END / ONLY_FOR_DEMO_YOU_CAN_DELETE_IT
    {
        path: '',
        component: RootComponent,
        data: {
            // Header layout. Choose one of ['classic', 'compact'].
            headerLayout: 'classic'
        },
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: PageHomeOneComponent
            },
            {
                path: 'shop',
                loadChildren: () => import('./modules/shop/shop.module').then(m => m.ShopModule)
            },
            {
                path: 'blog',
                loadChildren: () => import('./modules/blog/blog.module').then(m => m.BlogModule)
            },
            {
                path: 'account',
                loadChildren: () => import('./modules/account/account.module').then(m => m.AccountModule)
            },
            {
                path: 'site',
                loadChildren: () => import('./modules/site/site.module').then(m => m.SiteModule)
            },
            {
                path: '**',
                component: PageNotFoundComponent
            }
        ],
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {
        scrollPositionRestoration: 'enabled',
        anchorScrolling: 'enabled',
        initialNavigation: 'enabled'
    })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
