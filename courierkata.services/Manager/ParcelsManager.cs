using System.Collections.Generic;

namespace courierkata.services
{
    public class ParcelsManager : IParcelsManager
    {
        private readonly IParcelsCollectionInfoFactory _parcelsCollectionInfoFactory;
        // Total price of the order
        public int TotalPrice { get; set; } 
        public int TotalWeight { get; set; }
        public int SpeedyDeliveryCost { get; set; }

        public ParcelsCollectionInfo SmallParcelsCollection 
        { 
            get 
            {
                return _parcelsCollectionInfoFactory.GetParcelsCollectionInfoByLabel("S"); 
            }
        }
        
        public ParcelsCollectionInfo MediumParcelsCollection 
        { 
            get 
            {
                return _parcelsCollectionInfoFactory.GetParcelsCollectionInfoByLabel("M"); 
            }
        }

        public ParcelsCollectionInfo LargeParcelsCollection 
        { 
            get 
            {
                return _parcelsCollectionInfoFactory.GetParcelsCollectionInfoByLabel("L"); 
            }
        }
        
        public ParcelsCollectionInfo XLParcelsCollection 
        { 
            get 
            {
                return _parcelsCollectionInfoFactory.GetParcelsCollectionInfoByLabel("XL"); 
            }
        }
        
        public ParcelsManager(IParcelsCollectionInfoFactory parcelsCollectionInfoFactory)
        {
            _parcelsCollectionInfoFactory = parcelsCollectionInfoFactory;
        }

        public void AddParcelCost(Parcel parcel)
        {
            var parcelsCollection = _parcelsCollectionInfoFactory.CreateOrGetExistingParcelsCollectionInfo(
                parcel.Dimension, 
                parcel.Weight);

            parcelsCollection.Count++;
            parcelsCollection.TotalPrice += parcelsCollection.UnitPrice;
            TotalPrice += parcelsCollection.UnitPrice;
            if (parcel.Weight > parcelsCollection.WeightLimit)
            {
                var extraForWeight = parcelsCollection.ExtraWeightPrice * (parcel.Weight - parcelsCollection.WeightLimit);
                parcelsCollection.TotalPrice += extraForWeight;
                TotalPrice += extraForWeight;
            }
        }
    }
}