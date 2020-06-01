export interface QueryBuilder {
    toQueryMap: () => Map<string, string>;
    toQueryString: () => string;
  }
  
  export class QueryOptions<T> implements QueryBuilder {
    public search: T;
    public page: number;
    public pageSize: number;
    public query: string;
  
  
    constructor() {
      //this.page = 1;
      //this.pageSize = 10000;
      
    }
  
    toQueryMap() {
  
      const queryMap = new Map();
      queryMap.set('PageIndex', `${this.page}`);
      queryMap.set('PageSize', `${this.pageSize}`);
  
      if (this.search != undefined) {
        queryMap.set('search', this.search);
      }
      return queryMap;
    }
  
    toQueryString() {
      var queryString = '';
      this.toQueryMap().forEach((value: string, key: string) => {
        if (key != "search" && value != "undefined") {
          queryString = queryString.concat(`${key}=${value}&`);
        } else if(key == "search"){
          var a: any = value;
          for (var prop in a) {
            if (prop === "constructor")
              break;
  
            if (a[prop] == false || a[prop] == true || (a[prop] != "" && a[prop] != 0 && a[prop] != "null"))
              if(prop == "ApprovalCriterionLocation" || prop == "ApprovalCriterionMerchant" || prop == "ApprovalCriterionDistrict" || prop == "ApprovalCriterionCity" ){
                var b: any = value;
                for (var item in a[prop]) {
                  if (item === "constructor")
                  break;
                  if (item == prop && prop[item] == false || prop[item] == true || (prop[item] != "" && prop[item] != 0 && prop[item] != "null"))
                    queryString = queryString.concat(`${prop}=${a[prop][item]}&`);
              }
            }
            else 
            queryString = queryString.concat(`${prop}=${a[prop]}&`);
          }
        }
      });
      this.query = queryString.substring(0, queryString.length);
      return this.query;
    }
  }
  