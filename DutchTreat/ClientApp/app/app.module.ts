import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { DataService } from './shared/dataService';

@NgModule({
  declarations: [
      AppComponent,
      ProductList
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
  providers: [
    DataService // allows for data to be injected
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
