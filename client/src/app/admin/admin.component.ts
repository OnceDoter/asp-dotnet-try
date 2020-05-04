import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment'



@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit {
  jsonTable: any;


  constructor() { }

  ngOnInit(): void {
    this.getTableFromServer()
  }
  getTableFromServer(): void {

    var table = '<table class="table">'
    $.each(this.jsonTable, function (key, value) {
      var tableRow = '<tr>' +
        '<td>' + value.id + '</td>' +
        '<td>' + value.userName + '</td>' +
        '<td>' + value.email + '</td>' +
        '<td>' + value.phoneNumber + '</td>' +
        '</tr>';
      table += tableRow;
    });
    table += '</table>';
    $('#container').html(table);
  }

}

