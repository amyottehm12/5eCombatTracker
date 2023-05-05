import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EncounterGeneratorComponent } from './modules/encounter-generator/encounter-generator/encounter-generator.component';
import { OrderByPipe } from './helpers/order-by.pipe';
import { EncounterService } from './services/encounter.service';  


@NgModule({
  declarations: [
    AppComponent,
    EncounterGeneratorComponent,
    OrderByPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    EncounterService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
