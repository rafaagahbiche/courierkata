namespace courierkata.services
{
    public class ParcelsCollectionInfo
    {
        public int UnitPrice { get; set; }
        public int WeightLimit { get; set; }
        public int ExtraWeightPrice { get; set; }
        public string SizeLabel { get; set; }
        public ParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
        {
            UnitPrice = unitPrice;
            WeightLimit = weightLimit;
            ExtraWeightPrice = extraWeightPrice;
        }
    }

    public class SmallParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public SmallParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
            : base(unitPrice, weightLimit, extraWeightPrice)
        {
            SizeLabel = "S";
        }
    }

    public class MediumParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public MediumParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
            : base(unitPrice, weightLimit, extraWeightPrice)
        {
            SizeLabel = "M";
        }
    }

    public class LargeParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public LargeParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
            : base(unitPrice, weightLimit, extraWeightPrice)
        {
            SizeLabel = "L";
        }
    }

    public class XLParcelsCollectionInfo : ParcelsCollectionInfo
    {
        public XLParcelsCollectionInfo(int unitPrice, int weightLimit, int extraWeightPrice)
            : base(unitPrice, weightLimit, extraWeightPrice)
        {
            SizeLabel = "XL";
        }
    }
}