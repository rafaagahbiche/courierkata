using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public interface IOrderCostCalculator
    {
        OrderCost GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery);
    }
}