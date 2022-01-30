import { Component, OnInit, Inject, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MatDialogConfig, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as _ from 'lodash';
import { MessageService } from '../shared/message.service';
import { ChapterService } from '../shared/chapter.service';
import { formatDate } from '@angular/common';
import {MatSnackBar} from '@angular/material/snack-bar';
@Component({
  selector: 'app-creation',
  templateUrl: './creation.component.html',
  styleUrls: ['./creation.component.css']
})
export class CreationComponent implements OnInit, AfterViewInit {

  constructor(
    public dataAccessService: ChapterService, 
    private messageSvc: MessageService,
    public dialogRef: MatDialogRef<CreationComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBar: MatSnackBar
  ) { }

  isUpdate: boolean = false;
  categoryList: any = [];
  form: FormGroup;
  selectedElement: any = [];
  category: any = [];

  ngOnInit(): void {
    this.isUpdate = this.data.isUpdate;
    this.categoryList = this.data.categoryList;
    this.form = new FormGroup({
      chapter_Id: new FormControl(null),
      tittle: new FormControl('', Validators.required),
      active: new FormControl(true),
      selectedCategory: new FormControl([], Validators.minLength(1)),
      departmentType: new FormControl('', Validators.minLength(1)),
      publishedDatetime: new FormControl('', Validators.required),
    })
  }

  ngAfterViewInit(): void {
    if (!this.isUpdate) {
      this.initializeFormGroup();
    }
    else {
      this.populateFormGroup(this.data.dataRow)
    }
  }

  initializeFormGroup() {
    this.form.setValue({
      chapter_Id: null,
      tittle: '',
      active: true,
      selectedCategory: [],
      departmentType: "-1",
      publishedDatetime: formatDate(new Date(), "MM-dd-yyyy", "en-US")
    });
  }
  populateFormGroup(row) {
    this.selectedElement = [];
    this.category = row.selectedCategory;
    row.selectedCategory = [];
    this.category.forEach(element => {
      row.selectedCategory.push(element.category_Id);
    }); 
    this.form.setValue(_.omit(row,'selCategory'));
   //this.form.setValue(row);
  }
  onClose() {
    this.dialogRef.close();
  }
  /* onClear() {
   // this.form.reset();
   // this.initializeFormGroup();
    this.dialogRef.close();
  } */
  onSubmit() {
    if (this.form.valid) {
      if (!this.form.get('chapter_Id').value){
        this.dataAccessService.postChapterDetail(this.form.value).subscribe((data)=>{
          if(data.status ==200){
            this._snackBar.open("Data Added Successfully","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
            });
            this.onClose();
          }else{
            this._snackBar.open("Data Addition failed","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
            });
            this.onClose();
          }
        });
      }
      else{
        this.dataAccessService.putChapterDetail(this.form.value).subscribe((data)=>{
          if(data.status ==200){
            this._snackBar.open("Data Updated Successfully","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
            });
            this.onClose();
          }else{
            this._snackBar.open("Data Updation Failed","Close", {
              horizontalPosition: 'end',
              verticalPosition: 'top',
              duration: 5000
            });
            this.onClose();
          }
          
        });
      }
      this.form.reset();
      this.initializeFormGroup();
      //this.notificationService.success(':: Submitted successfully');
      this.onClose();
    }
  }
}
