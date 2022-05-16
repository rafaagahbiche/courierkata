namespace courierkata.services
{
    public interface IParcelsManager
    {
        int TotalPrice { get; set; } 
        int TotalWeight { get; set; }
        ParcelsCollectionInfo SmallParcelsCollection {get; }
        int SpeedyDeliveryCost { get; set; }
        ParcelsCollectionInfo MediumParcelsCollection {get; }

        ParcelsCollectionInfo LargeParcelsCollection {get; }
        ParcelsCollectionInfo XLParcelsCollection { get; } 
        void AddParcelCost(Parcel parcel);
    }
}