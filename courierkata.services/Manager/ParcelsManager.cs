using System.Collections.Generic;

namespace courierkata.services
{
    public class ParcelsManager : IParcelsManager
    {
        private readonly IParcelsCollectionInfoFactory _parcelsCollectionInfoFactory;
        // Total price of the order
        public OrderCostInfo OrderCostInfo { get; }
        
        public ParcelsManager(IParcelsCollectionInfoFactory parcelsCollectionInfoFactory)
        {
            _parcelsCollectionInfoFactory = parcelsCollectionInfoFactory;
            OrderCostInfo = new OrderCostInfo();
        }

        public OrderCostInfo GetOrderCostInfo(List<Parcel> parcels, bool speedyDelivery)
        {
            foreach(var parcel in parcels)
            {
                AddParcelCost(parcel);
            }

            if (speedyDelivery)
            {
                OrderCostInfo.SpeedyDeliveryCost = OrderCostInfo.TotalPrice*2;
            }

            return OrderCostInfo;
        }

        public void AddParcelCost(Parcel parcel)
        {
            var parcelsCollection = _parcelsCollectionInfoFactory.CreateOrGetExistingParcelsCollectionInfo(
                parcel.Dimension, 
                parcel.Weight);

            AddCostToParcelsCollectionPrice(parcelsCollection.UnitPrice, parcelsCollection.SizeLabel, true);
            OrderCostInfo.TotalPrice += parcelsCollection.UnitPrice;
            if (parcel.Weight > parcelsCollection.WeightLimit)
            {
                var extraForWeight = parcelsCollection.ExtraWeightPrice * (parcel.Weight - parcelsCollection.WeightLimit);
                AddCostToParcelsCollectionPrice(extraForWeight, parcelsCollection.SizeLabel, false);
                OrderCostInfo.TotalPrice += extraForWeight;
            }
        }

        private void AddCostToParcelsCollectionPrice(int price, string sizeLabel, bool incCount)
        {
            switch (sizeLabel)
            {
                case "S": 
                {
                    OrderCostInfo.SmallParcelsCollection.TotalPrice += price;
                    if (incCount) 
                    {
                        OrderCostInfo.SmallParcelsCollection.Count++;
                    }
                    return;
                };
                case "M": 
                {
                    OrderCostInfo.MediumParcelsCollection.TotalPrice += price;
                    if (incCount) 
                    {
                        OrderCostInfo.MediumParcelsCollection.Count++;
                    }
                    return;
                };
                case "L": 
                {
                    OrderCostInfo.LargeParcelsCollection.TotalPrice += price;
                    if (incCount) 
                    {
                        OrderCostInfo.LargeParcelsCollection.Count++;
                    }
                    return;
                };
                case "XL": 
                {
                    OrderCostInfo.XLParcelsCollection.TotalPrice += price;
                    if (incCount) 
                    {
                        OrderCostInfo.XLParcelsCollection.Count++;
                    }
                    return;
                };
                default : return;
            }
        }
    }
}