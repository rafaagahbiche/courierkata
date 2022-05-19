using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using courierkata.services;

namespace courierkata.tests
{
    [TestClass]
    public class OrderCostCalcultorTest
    {
        public ParcelsManager MyParcelsManager { get; set; }

        public OrderCostCalcultorTest()
        {
            // var parcelsCollectionFactoryMock = new Mock<IParcelsCollectionInfoFactory>();
            var parcelsCollectionFactory = new ParcelsCollectionInfoFactory();
            // parcelsCollectionFactoryMock.Setup(p => p.)
            MyParcelsManager = new ParcelsManager(parcelsCollectionFactory);
            // MyOrderCostCalculator = new OrderCostCalculator(MyParcelsManager);
        }

        [TestMethod]
        public void GetInfoForOrderFirstTest()
        {
            var orderCost = MyParcelsManager.GetOrderCostInfo(ParcelsFixture.MyFirstOrderParcels, false);
            Assert.AreEqual(3, orderCost.TotalPrice);
            Assert.AreEqual(3, orderCost.SmallParcelsCollection.TotalPrice);
            Assert.AreEqual(1, orderCost.SmallParcelsCollection.Count);
        }

        [TestMethod]
        public void GetInfoForOrderSpeedyDelivery()
        {
            var orderCost = MyParcelsManager.GetOrderCostInfo(ParcelsFixture.MyFirstOrderParcels, true);
            Assert.AreEqual(6, orderCost.SpeedyDeliveryCost);
        }

        [TestMethod]
        public void GetInfoForOrderManyParcels()
        {
            var orderCost = MyParcelsManager.GetOrderCostInfo(ParcelsFixture.MyMultipleParcels, false);
            Assert.AreEqual(46, orderCost.TotalPrice);
            Assert.AreEqual(8*2, orderCost.MediumParcelsCollection.TotalPrice);
            Assert.AreEqual(15*2, orderCost.LargeParcelsCollection.TotalPrice);
        }

        [TestMethod]
        public void GetInfoForOrderHeavyParcels()
        {
            // medium heavy parcel
            var orderCost = MyParcelsManager.GetOrderCostInfo(ParcelsFixture.MediumHeavyParcel, false);
            Assert.AreEqual(8 + 50, orderCost.TotalPrice);
        }
    }
}