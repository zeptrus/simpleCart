module app {
    class OrdersController {
        public orders: Order[];
        public customerLookup: { [customerId: string]: Customer[] } = {};

        constructor(OrderService: IOrderService, CustomerService: ICustomerService) {
            OrderService.searchOrders(null).then(data => {
                this.orders = data;
            });
            CustomerService.getAll().then(data => {
                console.log(data);
            });
        }
    }

    angular.module('app').controller('OrdersController', OrdersController);
}