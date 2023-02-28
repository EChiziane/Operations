import { Component } from '@angular/core';

@Component({
  selector: 'app-media',
  templateUrl: './media.component.html',
  styleUrls: ['./media.component.css']
})
export class MediaComponent {


public  change(){
var cl = document.querySelector(".close-btn");
  cl?.classList.toggle("open");
  }



}
