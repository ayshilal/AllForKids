import { List } from "lodash";

export class Response {
  RespCode: number;
  RespMessage: string;
  Result: boolean;
  TotalCount: number;
  Data: string;
  File: any;
  Errors: string;
}
export class ResponseBase {
  Id: number;
  Name: string;
}
export class ResponseSearchModel {
  ID: number;
  Name: string;
}
export class ResponseEditModel {
  Id: number;
  ID: number;
  Name: string;
}
