using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using courierkata.services;

namespace courierkata.tests
{
    [TestClass]
    public class OrderCostCalcultorTest
    {
        public List<Parcel> MyFirstOrderParcels { get; set; }
        public List<Parcel> MyMultipleParcels { get; set; }
        public OrderCostCalculator MyOrderCostCalculator { get; set; }
        public ParcelsManager MyParcelsManager { get; set; }
        public ParcelsCollectionInfoFactory MyParcelsCollectionInfoFactory { get; set; }

        public OrderCostCalcultorTest()
        {
            MyParcelsCollectionInfoFactory = new ParcelsCollectionInfoFactory();
            MyParcelsManager = new ParcelsManager(MyParcelsCollectionInfoFactory);
            MyOrderCostCalculator = new OrderCostCalculator(MyParcelsManager);
            MyFirstOrderParcels = new List<Parcel>() {
                new Parcel(){
                    Dimension = 1
                }
            };

            MyMultipleParcels= new List<Parcel>(){
                new Parcel() {
                    Dimension = 30
                },
                new Parcel() {
                    Dimension = 40,
                },
                new Parcel() {
                    Dimension = 60,
                },
                new Parcel() {
                    Dimension = 60,
                }
            };
        }

        [TestMethod]
        public void GetInfoForOrderFirstTest()
        {
            var orderCost = MyOrderCostCalculator.GetInfoForOrder(MyFirstOrderParcels, false);
            Assert.AreEqual(3, orderCost.TotalPrice);
            Assert.AreEqual(3, orderCost.SmallParcelsCollection.TotalPrice);
            Assert.AreEqual(1, orderCost.SmallParcelsCollection.Count);
        }

        [TestMethod]
        public void GetInfoForOrderSpeedyDelivery()
        {
            var orderCost = MyOrderCostCalculator.GetInfoForOrder(MyFirstOrderParcels, true);
            Assert.AreEqual(6, orderCost.SpeedyDeliveryCost);
        }

        [TestMethod]
        public void GetInfoForOrderManyParcels()
        {
            var orderCost = MyOrderCostCalculator.GetInfoForOrder(MyMultipleParcels, false);
            Assert.AreEqual(46, orderCost.TotalPrice);
            Assert.AreEqual(8*2, orderCost.MediumParcelsCollection.TotalPrice);
            Assert.AreEqual(15*2, orderCost.LargeParcelsCollection.TotalPrice);
        }

        [TestMethod]
        public void GetInfoForOrderHeavyParcels()
        {
            // medium heavy parcel
            var heavyOrder = new List<Parcel>() {(new Parcel() { Dimension = 20, Weight = 100})};
            var orderCost = MyOrderCostCalculator.GetInfoForOrder(heavyOrder, false);
            Assert.AreEqual(8 + 50, orderCost.TotalPrice);
        }
    }
}