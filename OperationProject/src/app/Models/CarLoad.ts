import {Client} from "./client";
import {Driver} from "./driver";
import {Destination} from "./Destination";
import {Material} from "./Material";

export interface CarLoad {
  id: number;
  date: string;
  amount: number;
  material: Material;
  client: Client;
  driver: Driver;
  destination: Destination

}
