using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCostCalculator: IOrderCostCalculator
    {
        private readonly ParcelsManager _parcelsManager;

        public OrderCostCalculator(ParcelsManager parcelsManager)
        {
            _parcelsManager = parcelsManager;
        }

        public ParcelsManager GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery)
        {
            foreach(var parcel in parcels)
            {
                _parcelsManager.AddParcelCost(parcel);
                if (speedyDelivery)
                {
                    _parcelsManager.SpeedyDeliveryCost = _parcelsManager.TotalPrice*2;
                }
            }

            return _parcelsManager;
        }        
    }
}