import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule} from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';


import { EncounterHandlerComponent } from './core/modules/encounter-handler/encounter-handler.component';
import { RoundHandlerComponent } from './core/modules/encounter-handler/round-handler/round-handler.component';

import { InitiativeTimelineComponent } from './core/modules/encounter-handler/initiative-timeline/initiative-timeline.component';
import { EncounterSetupComponent } from './core/modules/encounter-handler/encounter-setup/encounter-setup.component';
import { AdminComponent } from './core/modules/admin/admin.component';
import { MonsterDetailsComponent } from './core/modules/encounter-handler/initiative-timeline/monster-details/monster-details.component';
import { MonsterDetailsModalComponent } from './core/modules/encounter-handler/initiative-timeline/monster-details/monster-details-modal/monster-details-modal.component';
import { CharacterInputComponent } from './core/modules/character-input/character-input.component';
import { ContentComponent } from './core/modules/content/content.component';


@NgModule({
  declarations: [
    AppComponent,
    EncounterHandlerComponent,
    RoundHandlerComponent,
    MonsterDetailsComponent,
    InitiativeTimelineComponent,
    EncounterSetupComponent,
    AdminComponent,
    MonsterDetailsModalComponent,
    CharacterInputComponent,
    ContentComponent
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
    MatSelectModule,
    MatIconModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule
  ],
  providers: [  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
