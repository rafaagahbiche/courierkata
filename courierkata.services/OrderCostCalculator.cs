using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCostCalculator: IOrderCostCalculator
    {
        private readonly IParcelsManager _parcelsManager;

        public OrderCostCalculator(IParcelsManager parcelsManager)
        {
            _parcelsManager = parcelsManager;
        }

        public OrderCostInfo GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery)
        {
            foreach(var parcel in parcels)
            {
                _parcelsManager.AddParcelCost(parcel);
            }

            if (speedyDelivery)
            {
                _parcelsManager.OrderCostInfo.SpeedyDeliveryCost = _parcelsManager.OrderCostInfo.TotalPrice*2;
            }

            return _parcelsManager.OrderCostInfo;
        }        
    }
}