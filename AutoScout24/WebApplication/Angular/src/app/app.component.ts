import { Component } from '@angular/core';
import { FileData } from 'src/model/file-data';
import { ReportResult } from 'src/model/report-result';
import { FileUploadService } from 'src/service/file-upload-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Angular';
  result : any;

  listingFileCsv : string;
  reportResult : ReportResult;

  constructor(private fileUploadService : FileUploadService)
  {

  }

  ngOnInit()
  {
  
  }

  onFileChanged($event)
  {
    var that = this;
    let inputFile= $event.target.files[0];
    var reader = new FileReader();
     reader.onload = (e)=> {
      var binaryString = <string>reader.result;
      var b64String = window.btoa(binaryString);
      that.listingFileCsv = b64String;
    };
    reader.readAsBinaryString(inputFile);
  }

  uploadClicked()
  {
    var fileData = new FileData();
    fileData.listingFile = this.listingFileCsv;

    this.fileUploadService.importCsv(fileData).subscribe( res => 
    {
      this.reportResult = res;
    },  
    err => 
    {
 
    });
  }

}
