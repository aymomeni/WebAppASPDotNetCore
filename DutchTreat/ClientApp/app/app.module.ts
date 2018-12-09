import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { Shop } from "./shop/shop.component";
import { Checkout } from "./checkout/checkout.component";
import { Cart } from './shop/cart.component';
import { DataService } from './shared/dataService';
import { Login } from "./login/login.component";

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";

let routes = [
    { path: "", component: Shop },
    { path: "checkout", component: Checkout },
    { path: "login", component: Login }
];

@NgModule({
  declarations: [
      AppComponent,
      ProductList,
      Shop,
      Checkout,
      Cart,
      Login
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(routes, {
          useHash: true,
          enableTracing: false // for debugging of the routes
      })
  ],
  providers: [
    DataService // allows for data to be injected
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
