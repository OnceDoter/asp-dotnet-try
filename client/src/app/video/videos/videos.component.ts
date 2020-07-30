import { Component, OnInit } from '@angular/core';
import {Video} from '../../models/video';
import {HttpClient} from '@angular/common/http';
import {VideoService} from '../../services/video.service';
import {Router} from '@angular/router';
import {Image} from '../../models/image';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.css']
})
export class VideosComponent implements OnInit {

  userIcon: Image;
  videos: Video[];
  selectedVideo: Video;

  constructor(
    private http: HttpClient,
    private  videoService: VideoService,
    private router: Router,
    private authService: AuthService) {

  }

  ngOnInit(): void {
    if (!this.authService.getToken()){
      this.router.navigate(['login']);
    }
    this.fetchVideos();
    console.log(this.videos);
    if (this.videos === undefined){
      this.router.navigate(['videos/create']);
    }
  }

  onSelect(video: Video) {
    this.selectedVideo = video;
  }

  fetchVideos() {
    this.videoService.getVideos().subscribe(videos => {
      this.videos = videos;
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
