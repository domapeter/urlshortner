import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil, finalize } from 'rxjs';
import { LinkService } from 'src/app/services/link.service';
import { ShortLinkResponse } from 'src/app/ShortLinkResponse';

@Component({
  selector: 'app-resolve-link-component',
  templateUrl: './resolve-link.component.html'
})
export class ResolveLinkComponent implements OnInit, OnDestroy {
    private ngUnsubscribe = new Subject();

    public resolvedUrl:string|null=null;
    constructor(private activatedRoute: ActivatedRoute,
        private linkService: LinkService,
        @Inject(DOCUMENT) private document: Document
       ) { }

    ngOnInit(): void {
        const linkText = this.activatedRoute.snapshot.params['id']+"";
        this.linkService.get$(linkText).pipe(
            takeUntil(this.ngUnsubscribe)
        )
            .subscribe((res: ShortLinkResponse) => {
                this.resolvedUrl = res.url;
                this.document.location.href = this.resolvedUrl+"";
            });
    }

    ngOnDestroy(): void {
        this.ngUnsubscribe.next(void 0);
        this.ngUnsubscribe.complete();
    }
}
