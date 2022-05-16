using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCost
    {
        // Total price of the order
        public int TotalPrice { get; set; } 
        public int TotalWeight { get; set; }

        public int SpeedyDeliveryCost { get; set; }

        public ParcelsCollectionInfo SmallParcelsCollectionFromOrder { get; } 
        public ParcelsCollectionInfo MediumParcelsCollectionFromOrder { get; } 
        public ParcelsCollectionInfo LargeParcelsCollectionFromOrder { get; } 
        public ParcelsCollectionInfo XLParcelsCollectionFromOrder { get; } 

        // Price by dimension, the keys are s, m, l or xl
        public OrderCost()
        {
            SmallParcelsCollectionFromOrder = new SmallParcelsCollectionInfo(3,1, 2);
            MediumParcelsCollectionFromOrder = new MediumParcelsCollectionInfo(8,3,2);
            LargeParcelsCollectionFromOrder = new LargeParcelsCollectionInfo(15,6,2);
            XLParcelsCollectionFromOrder = new XLParcelsCollectionInfo(25,10,2);
        }
    }
}