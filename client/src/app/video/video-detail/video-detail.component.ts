import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {VideoService} from '../../services/video.service';
import {Video} from '../../models/video';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-video-detail',
  templateUrl: './video-detail.component.html',
  styleUrls: ['./video-detail.component.css']
})
export class VideoDetailComponent implements OnInit {
  id: string;
  video: Video;
  constructor(private route: ActivatedRoute, private videoService: VideoService) {
    this.fetchData();
  }

  fetchData() {
    this.route.params.pipe(map(params => {
      const id = params.id;
      return id;
    }), mergeMap(id => this.videoService.getVideo(id))).subscribe(res => {
      this.video = res;
    });
  }

  ngOnInit() {
  }

}
