namespace courierkata.services
{
    public class ParcelsCollectionInfoFactory : IParcelsCollectionInfoFactory
    {
        // each parcel collection will be created only once
        private static ParcelsCollectionInfo _parcelsCollectionInfo;
        private static SmallParcelsCollectionInfo _smallParcelsCollectionInfo;
        private static MediumParcelsCollectionInfo _mediumParcelsCollectionInfo;
        private static LargeParcelsCollectionInfo _largeParcelsCollectionInfo;
        private static XLParcelsCollectionInfo _xlParcelsCollectionInfo;
        // unit price
        private static readonly int _smallParcelUnitPrice = 3; 
        private static readonly int _mediumParcelUnitPrice = 8; 
        private static readonly int _largeParcelUnitPrice = 15; 
        private static readonly int _xlParcelUnitPrice = 25;

        // weight limit
        private static readonly int _smallParcelWeightLimit = 1; 
        private static readonly int _mediumParcelWeightLimit = 3; 
        private static readonly int _largeParcelWeightLimit = 6; 
        private static readonly int _xlParcelWeightLimit = 10;
        private static readonly int _heavyParcelWeightLimit = 50;

        // extra weight price 
        private static readonly int _regularExtraWeightPrice = 2; 
        private static readonly int _heavyExtraWeightPrice = 1; 

        public ParcelsCollectionInfo GetParcelsCollectionInfoByLabel(string label)
        {
            switch (label)
            {
                case "S": return _smallParcelsCollectionInfo;
                case "M": return _mediumParcelsCollectionInfo;
                case "L": return _largeParcelsCollectionInfo;
                case "XL": return _xlParcelsCollectionInfo;
                default : return _parcelsCollectionInfo;
            }
             
        }
        public ParcelsCollectionInfo CreateOrGetExistingParcelsCollectionInfo(
            int dimension,
            int weight)
        {
            var isSmallParcel = dimension > 0 && dimension < 10;
            var isMediumParcel = dimension >= 10 && dimension < 50;
            var isLargeParcel = dimension >= 50 && dimension < 100;
            var isXLParcel = dimension >= 100 ;
            if (weight > 50)
            {
                if (_parcelsCollectionInfo == null)
                {
                    _parcelsCollectionInfo = new ParcelsCollectionInfo(
                        isSmallParcel ? _smallParcelUnitPrice : 
                        isMediumParcel ? _mediumParcelUnitPrice :
                        isLargeParcel ? _largeParcelUnitPrice :
                        isXLParcel ? _xlParcelUnitPrice : 0, 
                        _heavyParcelWeightLimit, 
                        _heavyExtraWeightPrice);
                }
                return _parcelsCollectionInfo;
            }
            else if (isSmallParcel)
            {
                if (_smallParcelsCollectionInfo == null)
                {
                    _smallParcelsCollectionInfo = new SmallParcelsCollectionInfo(
                    _smallParcelUnitPrice, 
                    _smallParcelWeightLimit, 
                    _regularExtraWeightPrice);
                }
                return _smallParcelsCollectionInfo;
            }   
            else if (isMediumParcel)
            {
                if (_mediumParcelsCollectionInfo == null)
                {
                    _mediumParcelsCollectionInfo = new MediumParcelsCollectionInfo(
                        _mediumParcelUnitPrice, 
                        _mediumParcelWeightLimit, 
                        _regularExtraWeightPrice);
                }
                return _mediumParcelsCollectionInfo;
            }
            else if (isLargeParcel)
            {
                if (_largeParcelsCollectionInfo == null)
                {
                    _largeParcelsCollectionInfo = new LargeParcelsCollectionInfo(
                        _largeParcelUnitPrice, 
                        _largeParcelWeightLimit, 
                        _regularExtraWeightPrice);
                }
                return _largeParcelsCollectionInfo;
            }
            else if (isXLParcel)
            {
                if (_xlParcelsCollectionInfo == null)
                {
                    _xlParcelsCollectionInfo = new XLParcelsCollectionInfo(
                        _xlParcelUnitPrice, 
                        _xlParcelWeightLimit, 
                        _regularExtraWeightPrice);
                }
                return _xlParcelsCollectionInfo;
            }
            else 
            {
                return new ParcelsCollectionInfo(0,0,0);
            }
        }
    }
}