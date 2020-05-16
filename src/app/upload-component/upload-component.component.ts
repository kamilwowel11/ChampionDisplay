import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { UploadResult } from '../models/upload-result';
import { ChampionService } from '../services/champions/champions.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-upload-component',
  templateUrl: './upload-component.component.html',
  styleUrls: ['./upload-component.component.css']
})
export class UploadComponentComponent implements OnInit {

  uploadResult: UploadResult;
  @Output() uploadFinished = new EventEmitter();
 
  constructor(private championService: ChampionService) { }
 
  ngOnInit() {
  }
 
  public uploadFile(files) {
    if (files.length === 0) {
      return;
    }
 
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.championService
    .uploadImage(formData)
    .pipe(first())
    .subscribe(result=>{
      this.uploadResult = result;
      if(result.success) {
        this.uploadFinished.emit(result.path);
      }      
    }); 
  }
}
