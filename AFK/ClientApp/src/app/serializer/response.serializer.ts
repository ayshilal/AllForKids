import { Response, ResponseEditModel } from '../models/response';
import { Injectable } from '@angular/core';
@Injectable()
export class ResponseSerializer {

   fromJson(res: any): Response {
    const response = new Response();
    if (typeof res.Result === 'undefined') {// if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.Result.Data;
      return response;
    }
    else {
      //response.RespCode = res.status;
      //response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.Result.Data; /// res.body.Result.Data //iletişim tipi düznle
      return response;
    }
  }

  fromFile(res: any): Response {
    const response = new Response();
    if (typeof res.Result === 'undefined') {// if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.body.Result.Data;
      response.File = res.body.Result.Data.Document;
      return response;
    }
    else {
      //response.RespCode = res.status;
      //response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.Result.Data; /// res.body.Result.Data //iletişim tipi düznle
      return response;
    }
  }
  fromJsonDropDown(res: any): Response {
    const response = new Response();
    if (typeof res.Result === 'undefined') {// if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      if (typeof res.body.Result.Data === 'undefined')
        response.Data = res.body.Result;
      else
         response.Data = res.body.Result.Data;
      return response;
    }
    else {
      //response.RespCode = res.status;
      //response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.body.Result.Data; /// res.body.Result.Data //iletişim tipi düznle
      return response;
    }
  }
  getToken(res: any): Response {
    const response = new Response();
    if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      response.Data = res.body.token;
      return response;
    }
  }
  getResultFromJson(res: any): Response {
    const response = new Response();
    response.Result = res.body.Result;
    return response;
  }
  getFullResponsefromJson(res: any): Response {
    const response = new Response();
    if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.body.result;
      return response;
    }
    else {
      response.RespCode = res.status;
      response.RespMessage = res.body.Result;
      response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.body.Result.Data;
      return response;
    }
  }

  fromJsonUpdate(res: any): Response {
    const response = new Response();
    if (typeof res.Result === 'undefined') {// if (typeof res.body.Result === 'undefined') {
      response.RespCode = res.status;
      response.RespMessage = res.statusText;
      return response;
    }
    else {
      //response.RespCode = res.status;
      //response.RespMessage = res.statusText;
      //response.TotalCount = res.body.Result.TotalCount;
      response.Data = res.Result.Data; /// res.body.Result.Data //iletişim tipi düznle
      return response;
    }
  }
  toJson(response: Response): any {
    return {
      data: response.Data,
      responsecode: response.RespCode
    };
  }

  fromEditModel(data: ResponseEditModel): any {
    return {
      id: data.Id,
      name: data.Name
    }
  }
}
