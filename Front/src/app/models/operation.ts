import {OperationType} from "./operationType";

export interface Operation {
  id: number;
  key: number;
  date?:Date;
  value:number;
  description: string
  operationType: OperationType;
}
