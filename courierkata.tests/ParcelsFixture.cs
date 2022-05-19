using System.Collections.Generic;
using courierkata.services;

namespace courierkata.tests
{
    public static class ParcelsFixture
    {
        public static List<Parcel> MyFirstOrderParcels = new List<Parcel>() {
            new Parcel(){
                Dimension = 1
            }
        };

        public static List<Parcel> MyMultipleParcels = new List<Parcel>(){
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

        public static List<Parcel> MediumHeavyParcel = new List<Parcel>() {
            new Parcel() { Dimension = 20, Weight = 100}
        };
    }
}