import { Component, Inject } from '@angular/core';

import {
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';

import { IMonster } from 'src/app/core/models/IMonster';

@Component({
  selector: 'app-monster-details-modal',
  templateUrl: './monster-details-modal.component.html',
  styleUrls: ['./monster-details-modal.component.css']
})
export class MonsterDetailsModalComponent {
  public monster!: IMonster;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: IMonster,
    public dialogRef: MatDialogRef<MonsterDetailsModalComponent>,
  ) {
    this.monster = data;
  }

  close(): void {
    this.dialogRef.close();
  }
}
