import { environment } from 'src/environments/environment';

export class UrlString {

    readonly ApiUrl: string = environment.apiHost;
    readonly RelationsApiAlias: string = "/relations";
    readonly CountriesApiAlias: string = "/countries";

    RelationsUrlString: string = this.ApiUrl + this.RelationsApiAlias;
    CountriesUrlString: string = this.ApiUrl + this.CountriesApiAlias;

}