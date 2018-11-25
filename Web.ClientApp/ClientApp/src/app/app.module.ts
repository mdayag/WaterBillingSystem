import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
//import { Routes, RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { BarangayService } from "./services/barangay.service";

import { AppComponent } from "./app.component";
import { BarangayIndexComponent } from "./components/barangay/index/index.component";
import { BarangayCreateComponent } from "./components/barangay/create/create.component";
import { BarangayEditComponent } from "./components/barangay/edit/edit.component";
import { routing } from "./app-routing.module";
import { HttpModule } from "@angular/http";

@NgModule({
  declarations: [
    AppComponent,
    BarangayIndexComponent,
    BarangayCreateComponent,
    BarangayEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    routing,
    HttpModule
  ],
  providers: [BarangayService],
  bootstrap: [AppComponent]
})
export class AppModule {}
