import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
<<<<<<< HEAD
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
=======
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    NavComponent,
    HomeComponent,
    RegisterComponent
=======
    NavComponent
>>>>>>> d4787f3e6705b25e13a7f4dab66b06295295c9fd
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
