namespace courierkata.services
{
    public interface IParcelsCollectionInfoFactory
    {
        ParcelsCollectionInfo GetParcelsCollectionInfoByLabel(string label);
        ParcelsCollectionInfo CreateOrGetExistingParcelsCollectionInfo(int dimension, int weight);
    }
}