import { Component, OnInit,Inject } from '@angular/core';
import { MatDialog,MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.css']
})
export class ConfirmComponent implements OnInit {
  title: string;
  message: string;
  constructor(public dialogRef:MatDialogRef<ConfirmComponent>,@Inject(MAT_DIALOG_DATA)public data:ConfirmDialogModel) { 
    this.title = data.title;
    this.message = data.message;
  }

  ngOnInit(): void {
  }
  onConfirm(): void {
    // Close the dialog, return true
    this.dialogRef.close(true);
  }

  onDismiss(): void {
    // Close the dialog, return false
    this.dialogRef.close(false);
  }

}
export class ConfirmDialogModel {

  constructor(public title: string, public message: string) {
  }
}
