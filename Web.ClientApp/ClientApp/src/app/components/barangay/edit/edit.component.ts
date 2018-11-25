import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { BarangayService } from "src/app/services/barangay.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "barangay-edit",
  templateUrl: "./edit.component.html"
})
export class BarangayEditComponent implements OnInit {
  barangayForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private barangayService: BarangayService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    var id = this.activatedRoute.snapshot.params.id;

    this.barangayService.find(id).subscribe(
      res => {
        this.barangayForm = this.formBuilder.group({
          barangayId: res.barangayId,
          code: res.code,
          name: res.name
        });
      },
      error => {
        console.log(error);
      }
    );
  }

  update() {
    this.barangayService.update(this.barangayForm.value).subscribe(
      res => {
        this.router.navigate(["http://localhost:4200/barangay/index"]);
      },
      error => {
        //console.log(error);
      }
    );
  }
}
