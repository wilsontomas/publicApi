import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SpinnerService } from 'src/app/service/spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {
  loading$: Subject<Boolean> = this.spinner.isLoading$;

  constructor(private spinner: SpinnerService) {
    //console.log('spiner');
  }

  ngOnInit(): void {
    this.loading$ = this.spinner.isLoading$;
    //console.log(this.loading$);
  }
 

}
