import {Component} from '@angular/core';
import {Driver} from "../../../Models/driver";
import {Router} from "@angular/router";
import {DriverService} from "../../../services/driver.service";

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  styleUrls: ['./add-driver.component.css']
})
export class AddDriverComponent {
  driver: Driver = {
    firstName: "",
    lastName: "",
    mobile: "",
    id: 0
  }

  constructor(private router: Router,
              private driverService: DriverService) {
  }

  public createDriver(): void {
    this.driverService.addDriver(this.driver).subscribe(() => {
      this.router.navigate(['driver'])
    })
  }

}
