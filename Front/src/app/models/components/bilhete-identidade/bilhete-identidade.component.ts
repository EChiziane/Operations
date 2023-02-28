import {Component} from '@angular/core';

@Component({
  selector: 'app-bilhete-identidade',
  templateUrl: './bilhete-identidade.component.html',
  styleUrls: ['./bilhete-identidade.component.css']
})
export class BilheteIdentidadeComponent {
  public bilhetesIdentidade?: any;

  constructor() {
  }

  ngOnInit(): void {
    this.getBilheteIdentidade()
  }

  public getBilheteIdentidade() {
    this.bilhetesIdentidade = [{
      first_name: "Kelven",
      last_name: "Caio",
      numberId: "18293847589",
      Time: "12-03-2014"
    },
      {
        first_name: "Bruno",
        last_name: "Chirindza",
        numberId: "18293847589",
        Time: "12-03-2014"
      },
      {
        first_name: "Telma",
        last_name: "Caio",
        numberId: "92673847589",
        Time: "12-03-2014"
      }]
  }
}
