module app {
    export interface IOrderService {
        searchOrders(customerId: number): ng.IPromise<Array<Order>>;
    }

   export class OrderService {

        private url: string;

        constructor(private $http: ng.IHttpService, private $q: ng.IQService, config: any) {
            this.url = config.serviceUrl + "orders";
        }

        public searchOrders(customerId: number): ng.IPromise<Array<Order>> {
            var query = "";
            if (customerId != null) {
                query += "?customerId=" + customerId;
            }
            return this.$http.get<any>(this.url + query).then(response => {
                return response.data.map(OrderService.mapApiOrder);
            }, response => {
                return response.status
            });
        }

        public static mapApiOrder(apiData: IAPIOrder): Order {
            return {
                Id: apiData.Id,
                TotalPaid: apiData.TotalPaid,
                DatePlaced: new Date(apiData.DatePlaced),
                CustomerId: apiData.CustomerId
            };
        }
    }

   angular.module("app").service("OrderService", OrderService);
}