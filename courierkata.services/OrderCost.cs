using System.Collections.Generic;

namespace courierkata.services
{
    public class OrderCost
    {
        // Total price of the order
        public int TotalPrice { get; set; } 
        // Price by dimension, the keys are s, m, l or xl
        public Dictionary<string, ParcelSizeInfoInOrder> ParcelsInfo { get; set; }
        public OrderCost()
        {
            ParcelsInfo = new Dictionary<string, ParcelSizeInfoInOrder>(){
                {"s", new ParcelSizeInfoInOrder()},
                {"m", new ParcelSizeInfoInOrder()},
                {"l", new ParcelSizeInfoInOrder()},
                {"xl", new ParcelSizeInfoInOrder()}
            };
        }
    }
    
    public class ParcelSizeInfoInOrder
    {
        public int TotalPrice { get; set; } 
        public int Count { get; set; }
    }
}