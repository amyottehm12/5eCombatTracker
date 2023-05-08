import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EncounterHandlerComponent } from './modules/encounter-handler/encounter-handler.component';
import { RoundHandler } from './modules/encounter-handler/round-handler/round-handler.component';
import { MonsterDetailsComponent } from './modules/encounter-handler/monster-details/monster-details.component';
import { MonsterDetailsModalComponent } from './modules/encounter-handler/monster-details/monster-details-modal/monster-details-modal.component';  
import { InitiativeTimelineComponent } from './modules/encounter-handler/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './modules/encounter-handler/encounter-setup/encounter-setup.component';
import { AdminComponent } from './modules/admin/admin.component';


@NgModule({
  declarations: [
    AppComponent,
    EncounterHandlerComponent,
    RoundHandler,
    MonsterDetailsComponent,
    InitiativeTimelineComponent,
    EncounterSetupComponent,
    AdminComponent,
    MonsterDetailsModalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
