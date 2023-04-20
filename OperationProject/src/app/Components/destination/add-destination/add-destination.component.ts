import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {DestinationService} from "../../../services/destination.service";
import {Destination} from "../../../Models/Destination";

@Component({
  selector: 'app-add-destination',
  templateUrl: './add-destination.component.html',
  styleUrls: ['./add-destination.component.css']
})
export class AddDestinationComponent {
  destination: Destination = {
    id: 0,
    code: 0,
    description: ''
  }

  public constructor(private router: Router,
                     private destinationsService: DestinationService) {
  }

  public createDestination(): void {
    this.destinationsService.addDestination(this.destination).subscribe(() =>
      this.router.navigate(['/destination']))
  }
}
