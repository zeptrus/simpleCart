module app {
    export interface ICustomerService {
        getAll(): ng.IPromise<Array<Customer>>;
        getById(id: number): ng.IPromise<Customer>;
    }

   export class CustomerService {

        private url: string;

        constructor(config: any, private $http: ng.IHttpService) {
            this.url = config.serviceUrl + "customers";
        }

        public getAll(id: number): ng.IPromise<Array<Customer>> {
            return this.$http.get<any>(this.url).then(response => {
                return response.data.map(CustomerService.mapApiCustomer);
            }, response => {
                return response.status
            });
        }

        public getById(id: number): ng.IPromise<Customer> {
            return this.$http.get<any>(this.url + "/" + id).then(response => {
                return CustomerService.mapApiCustomer(response.data);
            }, response => {
                return response.status
            });
        }

        public static mapApiCustomer(apiData: IAPICustomer): Customer {
            return {
                Id: apiData.Id,
                FirstName: apiData.FirstName,
                LastName: apiData.LastName
            };
        }
    }

   angular.module("app").service("CustomerService", CustomerService);
}