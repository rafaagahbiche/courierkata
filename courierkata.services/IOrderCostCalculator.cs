using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public interface IOrderCostCalculator
    {
        OrderCostInfo GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery);
    }
}