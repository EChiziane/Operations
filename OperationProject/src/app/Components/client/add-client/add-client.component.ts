import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Client} from "../../../Models/client";
import {ClientService} from "../../../services/client.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent {

  client: Client = {
    id: 0,
    firstName: '',
    lastName: '',
    mobile: ''
  };

  constructor(private http: HttpClient,
              private clientService: ClientService,
              private router: Router) {
  }

  public createClient(): void {
    this.clientService.addClient(this.client!).subscribe(() => {
      this.router.navigate(['/client'])
    });
  }

}
