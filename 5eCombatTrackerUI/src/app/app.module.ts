import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule} from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { EncounterHandlerComponent } from './core/modules/encounter-handler/encounter-handler.component';
import { RoundHandlerComponent } from './core/modules/encounter-handler/round-handler/round-handler.component';

import { InitiativeTimelineComponent } from './core/modules/encounter-handler/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './core/modules/encounter-handler/encounter-setup/encounter-setup.component';
import { AdminComponent } from './core/modules/admin/admin.component';
import { MonsterDetailsComponent } from './core/modules/encounter-handler/initiative-timeline/monster-details/monster-details.component';
import { MonsterDetailsModalComponent } from './core/modules/encounter-handler/initiative-timeline/monster-details/monster-details-modal/monster-details-modal.component';
import { CombatLogComponent } from './core/modules/encounter-handler/combat-log/combat-log.component';


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
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    MatDialogModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  providers: [  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
