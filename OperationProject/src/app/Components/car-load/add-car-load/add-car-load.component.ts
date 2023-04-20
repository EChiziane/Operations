import {Component, OnInit} from '@angular/core';
import {CarLoad} from "../../../Models/CarLoad";
import {Material} from "../../../Models/Material";
import {Client} from "../../../Models/client";
import {Driver} from "../../../Models/driver";
import {Destination} from "../../../Models/Destination";
import {MaterialService} from "../../../services/material.service";
import {ClientService} from "../../../services/client.service";
import {DriverService} from "../../../services/driver.service";
import {DestinationService} from "../../../services/destination.service";
import {Router} from "@angular/router";
import {CarLoadService} from "../../../services/car-load.service";

@Component({
  selector: 'app-add-car-load',
  templateUrl: './add-car-load.component.html',
  styleUrls: ['./add-car-load.component.css']
})
export class AddCarLoadComponent implements OnInit {
  public materials: Material[] = [];
  selectedMaterial: number = 0
  public clients: Client[] = [];
  selectedClient: number = 0
  public drivers: Driver[] = [];
  selectedDriver: number = 0
  public destinations: Destination[] = [];
  selectedDestination: number = 0
  private material!: Material;
  private client!: Client;
  private driver!: Driver;
  private destination!: Destination;
  carload: CarLoad = {
    id: 0,
    date: "2023-04-12T02:20:18.904Z",
    amount: 0,
    destination: this.destination,
    driver: this.driver,
    client: this.client,
    material: this.material
  }

  constructor(private materialService: MaterialService,
              private clientService: ClientService,
              private driverService: DriverService,
              private destinationService: DestinationService,
              private carloadService: CarLoadService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.getClient();
    this.getMaterial();
    this.getDriver();
    this.getDestination()
  }


  public getMaterial(): void {
    this.materialService.getMaterial().subscribe({
      next: (materials: Material[]) => {
        this.materials = materials;
      },
      error: (error: any) => {
      },
    })
  }

  public getClient(): void {
    this.clientService.getClient().subscribe({
      next: (clients: Client[]) => {
        this.clients = clients;
      },
      error: (error: any) => {

      },
    })
  }

  public getDriver(): void {
    this.driverService.getDriver().subscribe({
      next: (drivers: Driver[]) => {
        this.drivers = drivers;
      },
      error: (error: any) => {

      },
    })
  }

  public getDestination(): void {
    this.destinationService.getDestination().subscribe({
      next: (destinations: Destination[]) => {
        this.destinations = destinations;
      },
      error: (error: any) => {
      },
    })
  }

  public selectMaterial(): void {
    this.materialService.getMaterialById(this.selectedMaterial).subscribe(
      (material: Material) => {
        this.carload.material = material
      }
    );
  }

  public selectClient(): void {
    this.clientService.getClientById(this.selectedClient).subscribe(
      (client: Client) => {
        this.carload.client = client
      }
    );
  }

  public selectDriver(): void {
    this.driverService.getDriverById(this.selectedDriver).subscribe(
      (driver: Driver) => {
        this.carload.driver = driver
      }
    );
  }

  public selectDestination(): void {
    this.destinationService.getDestinationById(this.selectedDestination).subscribe(
      (destination: Destination) => {
        this.carload.destination = destination
      }
    );
  }


  public createMaterial(): void {
    this.materialService.addMaterial(this.material).subscribe(() => {
      this.router.navigate(['/material'])
    })
  }

  public createCarLoad(): void {

    this.carloadService.addCarload(this.carload).subscribe(() => {
      this.router.navigate(['/carload'])
    })
  }


}

