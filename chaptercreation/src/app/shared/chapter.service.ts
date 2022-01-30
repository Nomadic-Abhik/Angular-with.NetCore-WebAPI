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
    return this.http.post(this.baseURL+'/PostChapter',formData);  
  }
  putChapterDetail(formData) {

    return this.http.put(this.baseURL+'/PostChapter',formData);  
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
