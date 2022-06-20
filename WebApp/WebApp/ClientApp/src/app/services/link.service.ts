import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject  } from "rxjs";
import { ShortLinkResponse } from "../ShortLinkResponse";

@Injectable({
    providedIn: 'root'
})
export class LinkService {

    static readonly apiEndpoint = 'api/URLShortner'
  

    constructor(
        private httpClient: HttpClient,
         @Inject('BASE_URL') private baseUrl: string
    ) {
        
    }

    get$(urlchunk :string){
        return this.httpClient.get<ShortLinkResponse>(this.baseUrl + LinkService.apiEndpoint+"/"+urlchunk)
    }

    create$(url: string) {
        var createRequest= {
            url: url
        }

        return this.httpClient.post<ShortLinkResponse>(this.baseUrl + LinkService.apiEndpoint, createRequest)
    }


}