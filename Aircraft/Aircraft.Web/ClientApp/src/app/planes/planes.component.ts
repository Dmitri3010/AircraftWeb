import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { planesServices } from './plane.service'
import { Plane } from 'src/models/plane';

@Component({
  selector: 'app-planes',
  templateUrl: './planes.component.html',
  styleUrls: ['./planes.component.css']
})

export class PlanesComponent implements OnInit {
  service: planesServices;
  public planesArr: any;


  constructor( service: planesServices) {
    this.service = service;
    this.planes();
    
  }

  planes(){
    let plane = this.service.getPlanes();
    plane.subscribe(result=> {
      this.planesArr=result as Plane[];
console.log(this.planesArr);
    });
  }

  ngOnInit() {
  }

}
