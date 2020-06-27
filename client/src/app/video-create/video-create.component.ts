import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VideoService} from '../services/video.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-video-create',
  templateUrl: './video-create.component.html',
  styleUrls: ['./video-create.component.css']
})
export class VideoCreateComponent {
  VideoForm: FormGroup;
  constructor(private fb: FormBuilder, private videoService: VideoService, private toastrService: ToastrService) {
    this.VideoForm = this.fb.group({
      ImageUrl: ['', Validators.required],
      Description: ['']
    });
  }

  get imgUrl() {
    return this.VideoForm.get('ImageUrl');
  }

  create() {
    this.videoService.createVideo(this.VideoForm.value).subscribe(res => {
      this.toastrService.success('Success');
      console.log(res);
    });
  }

}