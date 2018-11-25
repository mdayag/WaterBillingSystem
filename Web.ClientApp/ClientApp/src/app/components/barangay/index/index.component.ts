import { Component, OnInit } from "@angular/core";
import { Barangay } from "../../../models/barangay.model";
import { BarangayService } from "../../../services/barangay.service";
import { Router } from "@angular/router";

@Component({
  selector: "barangay-index",
  templateUrl: "./index.component.html"
})
export class BarangayIndexComponent implements OnInit {
  barangays: Barangay[];

  constructor(
    private barangayService: BarangayService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.barangayService.findAll().subscribe(
      res => {
        console.log("result: " + res);
        this.barangays = res;
      },
      error => {
        console.log(error);
      }
    );
  }

  edit(id: number) {
    this.router.navigate(["/barangay/edit/" + id]);
  }

  delete(barangayId: number) {
    var result = confirm("Are you sure you want to delete this item?");
    if (result) {
      this.barangayService.delete(barangayId).subscribe(
        res => {
          console.log(barangayId);
          //this.loadData();
          this.router.navigate(["/barangay/index"]);
        },
        error => {
          console.log(error);
        }
      );
    }
  }
}
