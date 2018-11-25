import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { BarangayIndexComponent } from "./components/barangay/index/index.component";
import { BarangayCreateComponent } from "./components/barangay/create/create.component";
import { BarangayEditComponent } from "./components/barangay/edit/edit.component";

const routes: Routes = [
  { path: "", component: BarangayIndexComponent },
  { path: "barangay/index", component: BarangayIndexComponent },
  { path: "barangay/create", component: BarangayCreateComponent },
  { path: "barangay/edit/:id", component: BarangayEditComponent }
];

export const routing = RouterModule.forRoot(routes);

//@NgModule({
//  imports: [RouterModule.forRoot(routes)],
//  exports: [RouterModule]
//})
//export class AppRoutingModule { }
