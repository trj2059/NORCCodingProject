using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ParkingLotLib.UnitTests
{
    public class Tests
    {
        private ParkingLot _parkingLot;

        [SetUp]
        public void Setup()
        {
            // build up our mock parking lot with 3 levels each with 100 spaces
            ParkingLotSpotSpace[,] parkingLotSpacesLevel0 = new ParkingLotSpotSpace[10,10];
            ParkingLotSpotSpace[,] parkingLotSpacesLevel1 = new ParkingLotSpotSpace[10,10];
            ParkingLotSpotSpace[,] parkingLotSpacesLevel2 = new ParkingLotSpotSpace[10,10];

            var parkingLotLevel0 = new ParkingLotLevel(0, parkingLotSpacesLevel0);
            var parkingLotLevel1 = new ParkingLotLevel(1, parkingLotSpacesLevel1);
            var parkingLotLevel2 = new ParkingLotLevel(2, parkingLotSpacesLevel2);

            var parkingLotLevels = new List<ParkingLotLib.ParkingLotLevel>() {
                parkingLotLevel0,parkingLotLevel1,parkingLotLevel2
            };

            _parkingLot = new ParkingLot(parkingLotLevels);
        }

        [Test]
        public void Park_Motorcycle_In_A_Motorcycle_Spot()
        {
            try
            {

            }
            catch(Exception ex)
            {
                Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
            }
        }
    }
}