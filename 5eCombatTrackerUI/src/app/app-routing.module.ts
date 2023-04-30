import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EncounterGeneratorComponent } from './modules/encounter-generator/encounter-generator/encounter-generator.component';

const routes: Routes = [
  {
    path: '',
    component: EncounterGeneratorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
