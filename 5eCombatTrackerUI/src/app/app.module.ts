import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { EncounterHandlerComponent } from './core/modules/encounter-handler/encounter-handler.component';
import { RoundHandlerComponent } from './core/modules/encounter-handler/round-handler/round-handler.component';
import { MonsterDetailsComponent } from './core/modules/encounter-handler/monster-details/monster-details.component';
import { MonsterDetailsModalComponent } from './core/modules/encounter-handler/monster-details/monster-details-modal/monster-details-modal.component';  
import { InitiativeTimelineComponent } from './core/modules/encounter-handler/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './core/modules/encounter-handler/encounter-setup/encounter-setup.component';
import { AdminComponent } from './core/modules/admin/admin.component';


@NgModule({
  declarations: [
    AppComponent,
    EncounterHandlerComponent,
    RoundHandlerComponent,
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
