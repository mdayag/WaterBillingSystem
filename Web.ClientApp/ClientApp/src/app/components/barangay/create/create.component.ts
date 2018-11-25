import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { BarangayService } from "src/app/services/barangay.service";
import { Router } from "@angular/router";

@Component({
  selector: "barangay-create",
  templateUrl: "./create.component.html"
})
export class BarangayCreateComponent implements OnInit {
  barangayForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private barangayService: BarangayService,
    private router: Router
  ) {}

  ngOnInit() {
    this.barangayForm = this.formBuilder.group({
      barangayId: 0,
      code: "",
      name: ""
    });
  }

  save() {
    this.barangayService.create(this.barangayForm.value).subscribe(
      res => {
        this.router.navigate(["/barangay/index"]);
      },
      error => {
        console.log(error);
      }
    );
  }
}
