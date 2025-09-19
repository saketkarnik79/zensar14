import { Injectable } from '@angular/core';
import { Product2 } from '../../models/Product2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductProxy {
  private readonly apiUrl:string="https://localhost:7129/api/ProductsApi";

  constructor(private http:HttpClient) { }

  httpOptions={
    headers: new HttpHeaders({'Content-Type':'application/json'})
  };

  getData(){
    return this.http.get<Product2[]>(this.apiUrl);
  }

  postData(formData:any):Observable<Product2>{
    return this.http.post<Product2>(this.apiUrl, formData, this.httpOptions);
  }

  putData(id:number, formData:any):Observable<Product2>{
    return this.http.put<Product2>(`${this.apiUrl}/${id}`, formData, this.httpOptions);
  }

  deleteData(id:number){
    return this.http.delete<Product2>(`${this.apiUrl}/${id}`);
  }
}
