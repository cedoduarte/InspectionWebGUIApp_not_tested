import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {
  readonly inspectionAPIUrl: string = "https://localhost:7188/api";

  constructor(private http: HttpClient) { }

  // Inspection
  getInspectionList(): Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + "/Inspection");
  }

  addInspection(data: any) {
    return this.http.post(this.inspectionAPIUrl + "/Inspection", data);
  }

  updateInspection(id: number | string, data: any) {
    return this.http.put(this.inspectionAPIUrl + `/inspection/${id}`, data);
  }
  
  deleteInspection(id: number | string) {
    return this.http.delete(this.inspectionAPIUrl + `/Inspection/${id}`);
  }
  // end Inspection

  // InspectionType
  getInspectionTypeList(): Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + "/InspectionType");
  }

  addInspectionType(data: any) {
    return this.http.post(this.inspectionAPIUrl + "/InspectionType", data);
  }

  updateInspectionType(id: number | string, data: any) {
    return this.http.put(this.inspectionAPIUrl + `/InspectionType/${id}`, data);
  }

  deleteInspectionType(id: number | string) {
    return this.http.delete(this.inspectionAPIUrl + `/InspectionType/${id}`);
  }
  // end InspectionType

  // Status
  getStatusList(): Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + "/Status");
  }

  addStatus(data: any) {
    return this.http.post(this.inspectionAPIUrl + "/Status", data);
  }

  updateStatus(id: number | string, data: any) {
    return this.http.put(this.inspectionAPIUrl + `/Status/${id}`, data);
  }

  deleteStatus(id: number | string) {
    return this.http.delete(this.inspectionAPIUrl + `/Status/${id}`);
  }
  // end Status
}
