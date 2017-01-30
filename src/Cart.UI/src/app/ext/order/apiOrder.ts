module app {
    export interface IAPIOrder {
        Id: number;
        TotalPaid: number;
        DatePlaced: string;
        CustomerId: number;
    }
}