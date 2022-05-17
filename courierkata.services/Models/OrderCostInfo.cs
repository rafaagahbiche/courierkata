namespace courierkata.services
{
    public class OrderCostInfo
    {
        public int TotalPrice { get; set; } 
        public int TotalWeight { get; set; }
        public int SpeedyDeliveryCost { get; set; }
        public ParcelsCollectionCostInfo SmallParcelsCollection { get; set; }
        public ParcelsCollectionCostInfo MediumParcelsCollection  { get; set; }
        public ParcelsCollectionCostInfo LargeParcelsCollection { get; set; }
        public ParcelsCollectionCostInfo XLParcelsCollection { get; set; }

        public OrderCostInfo()
        {
            SmallParcelsCollection = new ParcelsCollectionCostInfo();
            MediumParcelsCollection = new ParcelsCollectionCostInfo();
            LargeParcelsCollection = new ParcelsCollectionCostInfo();
            XLParcelsCollection = new ParcelsCollectionCostInfo();
        }
    }
}