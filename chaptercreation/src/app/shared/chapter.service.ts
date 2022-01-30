import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ChapterService {

  readonly baseURL = 'http://localhost:47287/api/chapter';

  constructor(private http: HttpClient) { }
  httpOptions = {  
    headers: new HttpHeaders({  
      'Content-Type': 'application/json'  
    })  
  } 
  postChapterDetail(formData) {
    formData.selCategory = formData.selectedCategory.join(',');
    formData.selectedCategory = null;
    return this.http.post(this.baseURL,formData,{observe: 'response'});  
  }
  putChapterDetail(formData) {
    formData.selCategory = formData.selectedCategory.join(',');
    formData.selectedCategory = null;
    return this.http.put(this.baseURL,formData,{observe: 'response'});  
  }
  deleteChapter(id: number) {
    return this.http.delete(this.baseURL+'?id='+id,{observe: 'response'});  
  }

  refreshList() {
    return this.http.get(this.baseURL);
  }
  getStaticData() {
    return this.http.get(this.baseURL+ '/getStaticData');
  }
}
