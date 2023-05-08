import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EncounterHandlerComponent } from './modules/encounter-handler/encounter-handler.component';
import { RoundHandler } from './modules/round-handler/round-handler.component';
import { EncounterService } from './services/encounter.service';
import { MonsterDetailsComponent } from './modules/monster-details/monster-details.component';
import { InitiativeTimelineComponent } from './modules/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './modules/encounter-setup/encounter-setup.component';  


@NgModule({
  declarations: [
    AppComponent,
    EncounterHandlerComponent,
    RoundHandler,
    MonsterDetailsComponent,
    InitiativeTimelineComponent,
    EncounterSetupComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    //EncounterService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
