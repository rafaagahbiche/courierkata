namespace courierkata.services
{
    public class ParcelsCollectionInfo
    {
        public int UnitPrice { get; set; }
        public int WeightLimit { get; set; }
        public int ExtraWeightPrice { get; set; }
        public string SizeLabel { get; set; }
        public int TotalPrice { get; set; } 
        public int Count { get; set; }
    }

    public class SmallParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public SmallParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
        {
            SizeLabel = "Small";
            UnitPrice = unitPrice;
            WeightLimit = weightLimit;
            ExtraWeightPrice = extraWeightPrice;
        }
    }

    public class MediumParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public MediumParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
        {
            SizeLabel = "Medium";
            UnitPrice = unitPrice;
            WeightLimit = weightLimit;
            ExtraWeightPrice = extraWeightPrice;
        }
    }

    public class LargeParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public LargeParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
        {
            SizeLabel = "Large";
            UnitPrice = unitPrice;
            WeightLimit = weightLimit;
            ExtraWeightPrice = extraWeightPrice;
        }
    }

    public class XLParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public XLParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
        {
            SizeLabel = "XL";
            UnitPrice = unitPrice;
            WeightLimit = weightLimit;
            ExtraWeightPrice = extraWeightPrice;
        }
    }
}