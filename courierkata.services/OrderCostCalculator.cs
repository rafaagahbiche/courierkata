using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCostCalculator: IOrderCostCalculator
    {
        public OrderCost GetInfoForOrder(List<Parcel> parcels)
        {
            var orderCost = new OrderCost();
            foreach(var parcel in parcels)
            {
                if (parcel.Dimension < 10)
                {
                    orderCost.TotalPrice += 3;
                    orderCost.ParcelsInfo["s"].TotalPrice += 3;
                    orderCost.ParcelsInfo["s"].Count++;
                }
            }

            return orderCost;
        }        
    }
}