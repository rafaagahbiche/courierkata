using System;
using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCostCalculator: IOrderCostCalculator
    {
        private void addPriceToParcelsCollection(
            Parcel parcel,
            OrderCost orderCost, 
            ParcelsCollectionInfo parcelsCollection)
        {
            orderCost.TotalPrice += parcelsCollection.UnitPrice;
            parcelsCollection.TotalPrice += parcelsCollection.UnitPrice;
            parcelsCollection.Count++;
            if (parcel.Weight > parcelsCollection.WeightLimit)
            {
                var extraForWeight = parcelsCollection.ExtraWeightPrice * (parcel.Weight - parcelsCollection.WeightLimit);
                parcelsCollection.TotalPrice += extraForWeight;
                orderCost.TotalPrice += extraForWeight;
            }
        }

        public OrderCost GetInfoForOrder(List<Parcel> parcels, bool speedyDelivery)
        {
            var orderCost = new OrderCost();
            foreach(var parcel in parcels)
            {
                if (parcel.Dimension > 0)
                {
                    if (parcel.Dimension < 10)
                    {
                        addPriceToParcelsCollection(
                            parcel,
                            orderCost, 
                            orderCost.SmallParcelsCollectionFromOrder);
                    }
                    else if (parcel.Dimension < 50)
                    {
                        addPriceToParcelsCollection(
                            parcel,
                            orderCost, 
                            orderCost.MediumParcelsCollectionFromOrder);
                    }
                    else if (parcel.Dimension < 100)
                    {
                        addPriceToParcelsCollection(
                            parcel,
                            orderCost, 
                            orderCost.LargeParcelsCollectionFromOrder);
                    }
                    else if(parcel.Dimension >= 100)
                    {
                        addPriceToParcelsCollection(
                            parcel,
                            orderCost, 
                            orderCost.XLParcelsCollectionFromOrder);
                    } 
                }
                if (speedyDelivery)
                {
                    orderCost.SpeedyDeliveryCost = orderCost.TotalPrice*2;
                }
            }

            return orderCost;
        }        
    }
}