using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using courierkata.services;

namespace courierkata.tests
{
    [TestClass]
    public class OrderCostCalcultorTest
    {
        [TestMethod]
        public void GetInfoForOrderFirstTest()
        {
            var parcel = new Parcel(){
                Dimension = 1
            };
            var myParcels = new List<Parcel>(){
                parcel
            };
            var orderCostCalculator = new OrderCostCalculator();
            var orderCost = orderCostCalculator.GetInfoForOrder(myParcels);
            Assert.AreEqual(3, orderCost.TotalPrice);
            Assert.AreEqual(3, orderCost.ParcelsInfo["s"].TotalPrice);
            Assert.AreEqual(1, orderCost.ParcelsInfo["s"].Count);
        }
    }
}
