namespace courierkata.services
{
    public interface IParcelsManager
    {
        OrderCostInfo OrderCostInfo { get; }
        void AddParcelCost(Parcel parcel);
    }
}