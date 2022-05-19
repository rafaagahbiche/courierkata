using System.Collections.Generic;
namespace courierkata.services
{
    public interface IParcelsManager
    {
        OrderCostInfo OrderCostInfo { get; }
        OrderCostInfo GetOrderCostInfo(List<Parcel> parcels, bool speedyDelivery);
        void AddParcelCost(Parcel parcel);
    }
}