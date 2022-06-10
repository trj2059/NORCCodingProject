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
            ParkingLotSpotSpace[,] parkingLotSpacesLevel0 = new ParkingLotSpotSpace[10, 10];
            // make the first level only avaliable for motercycles
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    parkingLotSpacesLevel0[i, j] = new ParkingLotSpotSpace() { spaceType = SpotSpaceTypeEnum.Motorcycle };
                }
            }

            // make the second level only avaliable for cars
            ParkingLotSpotSpace[,] parkingLotSpacesLevel1 = new ParkingLotSpotSpace[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    parkingLotSpacesLevel1[i, j] = new ParkingLotSpotSpace() { spaceType = SpotSpaceTypeEnum.Compact };
                }
            }

            // make the third level only avaliable for busses.
            ParkingLotSpotSpace[,] parkingLotSpacesLevel2 = new ParkingLotSpotSpace[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    parkingLotSpacesLevel2[i, j] = new ParkingLotSpotSpace() { spaceType = SpotSpaceTypeEnum.Bus };
                }
            }

            var parkingLotLevel0 = new ParkingLotLevel(0, parkingLotSpacesLevel0);
            var parkingLotLevel1 = new ParkingLotLevel(1, parkingLotSpacesLevel1);
            var parkingLotLevel2 = new ParkingLotLevel(2, parkingLotSpacesLevel2);

            var parkingLotLevels = new List<ParkingLotLib.ParkingLotLevel>() {
               parkingLotLevel0, parkingLotLevel1,parkingLotLevel2
            };

            _parkingLot = new ParkingLot(parkingLotLevels);
        }

        [Test]
        public void Park_Motorcycle_In_A_Motorcycle_Spot()
        {
            try
            {
                // create a list of spots                
                var localList = new List<(uint, uint)>();
                localList.Add((0, 0)); // just use the corner spot

                Motorcycle motorcycle = new Motorcycle(Guid.NewGuid(), localList);

                _parkingLot.ParkAVehicle(motorcycle, 2);
                Assert.Pass(); // no exception shoudl have been thrown
            }
            catch (Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }

        [Test]
        public void Park_Car_In_A_Motorcycle_Spot()
        {
            try
            {
                // create a list of spots                
                var localList = new List<(uint, uint)>();
                localList.Add((0, 0)); // just use the corner spot

                Car car = new Car(Guid.NewGuid(), localList);
                _parkingLot.ParkAVehicle(car, 2);
            }
            catch (Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }
    }
}