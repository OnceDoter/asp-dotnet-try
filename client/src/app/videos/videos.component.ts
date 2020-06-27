import { Component, OnInit } from '@angular/core';
import {Video} from '../models/video';
import {HttpClient} from '@angular/common/http';
import {VideoService} from '../services/video.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.css']
})
export class VideosComponent implements OnInit {

  videos: Video[];
  selectedVideo: Video;

  constructor(private http: HttpClient, private  videoService: VideoService, private router: Router) { }

  ngOnInit(): void {
    console.log('init videos component');
    this.fetchVideos();
  }

  onSelect(video: Video) {
    this.selectedVideo = video;
  }

  fetchVideos() {
    this.videoService.getVideos().subscribe(videos => {
      this.videos = videos;
      console.log(this.videos);
    });
  }

  editVideo(id) {
    this.router.navigate(['videos', id, 'edit']);
  }

  deleteVideo(id) {
    console.log('Hello');
    this.videoService.deleteVideo(id).subscribe(res => {
      this.fetchVideos();
    });
  }
}
