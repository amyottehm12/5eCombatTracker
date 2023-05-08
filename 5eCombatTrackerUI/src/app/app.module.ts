import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EncounterGeneratorComponent } from './modules/encounter-generator/encounter-generator.component';
import { MonsterAttacksComponent } from './modules/monster-attacks/monster-attacks.component';
import { EncounterService } from './services/encounter.service';
import { MonsterDetailsComponent } from './modules/monster-details/monster-details.component';
import { InitiativeTimelineComponent } from './modules/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './modules/encounter-setup/encounter-setup.component';  


@NgModule({
  declarations: [
    AppComponent,
    EncounterGeneratorComponent,
    MonsterAttacksComponent,
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
