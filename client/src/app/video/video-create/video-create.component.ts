import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VideoService} from '../../services/video.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-video-create',
  templateUrl: './video-create.component.html',
  styleUrls: ['./video-create.component.css']
})
export class VideoCreateComponent implements OnInit{
  VideoForm: FormGroup;
  constructor(private fb: FormBuilder, private videoService: VideoService, private toastrService: ToastrService) {
    this.VideoForm = this.fb.group({
      ImageUrl: ['', Validators.required],
      Description: ['']
    });
  }

  ngOnInit() {
    console.log('dsa');
  }

  get imgUrl() {
    return this.VideoForm.get('ImageUrl');
  }

  create() {
    this.videoService.curlVideo(this.VideoForm.value).subscribe(res => {
      this.toastrService.success('Success');
      console.log(res);
    });
  }

}
