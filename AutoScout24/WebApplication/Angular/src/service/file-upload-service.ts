import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Listing } from 'src/model/listing';
import { FileData } from 'src/model/file-data';
import { ReportResult } from 'src/model/report-result';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  url = 'https://localhost:44396/api/values';  // URL to web api
  uploadUrl = 'https://localhost:44396/api/values/upload';  // URL to web api

  constructor(private http: HttpClient) { }

    getResult(): Observable<any> 
    {
      return this.http.get<any>(this.url);
    }

    importCsv(fileData : FileData) : Observable<ReportResult>
    {
      //return this.http.get<any>(this.url);

      return this.http.post<ReportResult>(this.uploadUrl, fileData);
    } 

}
