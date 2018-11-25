import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs";
import { Barangay } from "../models/barangay.model";
import { map } from "rxjs/operators";

@Injectable()
export class BarangayService {
  private BASE_URL: string = "https://localhost:44394/api/barangay/";

  constructor(private http: Http) {}

  findAll(): Observable<Barangay[]> {
    return this.http
      .get(this.BASE_URL + "findall")
      .pipe(map((res: Response) => res.json()));
  }

  find(barangayId: number): Observable<Barangay> {
    return this.http
      .get(this.BASE_URL + "find/" + barangayId)
      .pipe(map((res: Response) => res.json()));
  }

  create(barangay: Barangay) {
    return this.http
      .post(this.BASE_URL + "create", barangay)
      .pipe(map((res: Response) => res.json()));
  }

  update(barangay: Barangay) {
    return this.http
      .put(this.BASE_URL + "update", barangay)
      .pipe(map((res: Response) => res.json()));
  }

  delete(barangayId: number) {
    return this.http
      .delete(this.BASE_URL + "delete/" + barangayId)
      .pipe(map((res: Response) => res.json()));
  }
}
