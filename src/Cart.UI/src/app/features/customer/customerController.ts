module app {
    class CustomerController {
        public customer: Customer;
        public orders: Order[];

        constructor(CustomerService: ICustomerService, OrderService: IOrderService, $routeParams: any) {
            CustomerService.getById($routeParams["customerId"]).then(customer => {
                this.customer = customer;
                console.log(this.customer);
                OrderService.searchOrders(this.customer.Id).then(orders => {
                    this.orders = orders;
                });
            });
        }
    }

    angular.module('app').controller('CustomerController', CustomerController);
}