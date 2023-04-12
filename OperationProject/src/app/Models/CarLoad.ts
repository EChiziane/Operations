import {Client} from "./client";
import {Driver} from "./driver";
import {Destination} from "./Destination";

export interface CarLoad{
  id:number;
  date:string;
  amount:number;
  client:Client;
  driver:Driver;
  destination:Destination

}
