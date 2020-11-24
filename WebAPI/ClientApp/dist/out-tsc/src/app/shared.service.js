import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let SharedService = class SharedService {
    constructor(http) {
        this.http = http;
        this.ApiUrl = "https://localhost:44358/api";
        this.ApiAlias = "/relations";
    }
    getRelationsList() {
        //var result =
        return this.http.get(this.ApiUrl + this.ApiAlias);
        //debugger;
        //return result;
    }
    addRelation(val) {
        return this.http.post(this.ApiUrl + this.ApiAlias, val);
    }
    updateRelation(val) {
        return this.http.put(this.ApiUrl + this.ApiAlias, val);
    }
    deleteRelation(val) {
        return this.http.delete(this.ApiUrl + this.ApiAlias, val);
    }
};
SharedService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], SharedService);
export { SharedService };
//# sourceMappingURL=shared.service.js.map