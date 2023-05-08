import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EncounterHandlerComponent } from './modules/encounter-handler/encounter-handler.component';

const routes: Routes = [
  {
    path: '',
    component: EncounterHandlerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
