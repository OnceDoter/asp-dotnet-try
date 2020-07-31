import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Video} from '../models/video';
import {AuthService} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  private url = environment.apiUrl + 'Video';
  constructor(private  http: HttpClient, private authService: AuthService) { }

  getVideos(): Observable<Array<Video>>{
    return this.http.get<Array<Video>>(this.url + '/VideosByUser');
  }
  saveVideos(data){
    localStorage.setItem('videos', data);
  }
  curlVideo(data): Observable<Video>{
    return this.http.post<Video>(this.url + '/Create', data);
  }
  getVideo(id): Observable<Video> {
    return this.http.get<Video>(this.url + '/' + id);
  }
  editVideo(data) {
    return this.http.put(this.url, data);
  }
  deleteVideo(id){
    return this.http.delete(this.url, id);
  }

}
