import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, Subject, takeUntil } from 'rxjs';
import { LinkService } from 'src/app/services/link.service';

@Component({
  selector: 'app-create-link-component',
  templateUrl: './create-link.component.html'
})
export class CreateLinkComponent implements OnInit, OnDestroy {
    private ngUnsubscribe = new Subject();

    createLinkForm: FormGroup;

    public link:string|null=null;

    constructor(private router: Router,
        @Inject('BASE_URL') public baseUrl: string,
        private linkService: LinkService
        ) { 
        this.createLinkForm = new FormGroup({
            link: new FormControl(null, Validators.required)
        });
    }

    isLoading = false;

    ngOnInit(): void {
        
    }

    ngOnDestroy(): void {
        this.ngUnsubscribe.next(void 0);
        this.ngUnsubscribe.complete();
    }

    onSubmit() {
        const url = <string>this.createLinkForm.value;
        this.isLoading = true;

        this.linkService.create$(this.createLinkForm.get("link")?.value).subscribe(result => {
           this.link = result.shortUrl;
          }, error => console.error(error));
    }
}
