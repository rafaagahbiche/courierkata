using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public interface IOrderCostCalculator
    {
        ParcelsManager GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery);
    }
}