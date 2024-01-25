import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EncounterHandlerComponent } from './core/modules/encounter-handler/encounter-handler.component';
import { AdminComponent } from './core/modules/admin/admin.component';
import { CharacterInputComponent } from './core/modules/character-input/character-input.component';

const routes: Routes = [
  { path: '', component: EncounterHandlerComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'characterinput', component: CharacterInputComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
