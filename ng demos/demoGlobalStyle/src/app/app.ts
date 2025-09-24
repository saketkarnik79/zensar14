import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Test } from "./test/test";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Test],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = 'Demo for Angular Global Style';
}
