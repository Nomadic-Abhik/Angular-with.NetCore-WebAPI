import { Component, OnInit, ViewChild } from '@angular/core';
import { ChapterService } from '../shared/chapter.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MessageService } from '../shared/message.service';
import { ConfirmComponent, ConfirmDialogModel } from '../shared/confirm/confirm.component';
import { MatDialog ,MatDialogConfig} from '@angular/material/dialog';
import {CreationComponent} from '../creation/creation.component';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.css']
})
export class ListingComponent implements OnInit {
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['Tittle', 'DepartmentTypeName', 'PublishedDateTime', 'category', 'active', 'actions'];
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;
  dataArray: any = [];
  staticdataArray: any =[];
  Form: FormGroup;

  constructor(public dataAccessService: ChapterService, private _snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getStaticData();
    this.getdata();
  }

  getdata() {
    this.dataAccessService.refreshList().subscribe((data: any[]) => {
      this.dataArray = data;
      this.listData = new MatTableDataSource(this.dataArray);
      this.listData.paginator = this.paginator;
    });
  }

  getStaticData() {
    this.dataAccessService.getStaticData().subscribe((data: any[]) => {
      this.staticdataArray = data;
    });
  }

  createRecord()
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "55%";
    dialogConfig.data = {isUpdate : false, categoryList : this.staticdataArray}
    const dialogRef = this.dialog.open(CreationComponent,dialogConfig);
    dialogRef.afterClosed().subscribe(dialogResult => {
      this.getdata();
    });
  }
  onEditRecord(val)
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "55%";
    dialogConfig.data = {isUpdate : true, dataRow: val, categoryList : this.staticdataArray}
    const dialogRef = this.dialog.open(CreationComponent,dialogConfig);
    dialogRef.afterClosed().subscribe(dialogResult => {
      this.getdata();
    });
  }
  deleteData(element) {
    const dialogData = new ConfirmDialogModel("Confirm Action", "Are you sure to Delete ?");
    const dialogRef = this.dialog.open(ConfirmComponent, {
      maxWidth: "400px",
      data: dialogData
    });
    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult) {
        this.dataAccessService.deleteChapter(element.chapter_Id).subscribe(response => {
          if (response.status == 200) {
            //this.messageSvc.showSuccess("Data Deleted Successfully", "Deletion");
            this._snackBar.open("Data Deleted Successfully","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
              
            })
            this.getdata();
          }
          else {
            //this.messageSvc.showError("Data Deletion Failure", "Deletion");
            this._snackBar.open("Data DDeletion Failure","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
            })
            this.getdata();
          }
        });
      }
      else {
        this.getdata();
      }
    });

  }

}
