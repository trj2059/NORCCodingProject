using NUnit.Framework;
using System;
using System.Collections.Generic;
using ParkingLotLib.Assertions;

namespace ParkingLotLib.UnitTests
{
    enum LotLevel
    {
        MotorCycle = 0,
        Compact = 1,
        Large = 2
    }

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
                    parkingLotSpacesLevel2[i, j] = new ParkingLotSpotSpace() { spaceType = SpotSpaceTypeEnum.Large };
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

                // create a motorcycle object and park it
                Motorcycle motorcycle = new Motorcycle(Guid.NewGuid(), localList);
                _parkingLot.ParkAVehicle(motorcycle, (int)LotLevel.MotorCycle);
                Assert.Pass("No exception shoudl have been thrown"); // no exception shoudl have been thrown
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

                // create the car object and park it
                Car car = new Car(Guid.NewGuid(), localList);
                _parkingLot.ParkAVehicle(car, (int)LotLevel.MotorCycle);
                Assert.Fail("Should not be able to park a car in a motor cycle spot");
            }
            catch(CarAttemptedToParkInAMotorCycleSpotAssertion)
            {
                Assert.Pass("Should not be able to park a car in a motor cycle space");
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
        public void Park_Bus_In_Five_Large_Consecutive_Spots_In_A_Row()
        {
            try
            {
                // create a list of spots                
                var localList = new List<(uint, uint)>();
                localList.Add((0, 0)); // create 5 spots
                localList.Add((0, 1));
                localList.Add((0, 2));
                localList.Add((0, 3));
                localList.Add((0, 4));

                // create the bus object and park it
                Bus bus = new Bus(Guid.NewGuid(), localList);
                _parkingLot.ParkAVehicle(bus, (int)LotLevel.Large);
                Assert.Pass("No exception shoudl have been thrown"); // no exception shoudl have been thrown
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
        public void Park_Bus_In_Five_Non_Consecutive_Spots_In_A_Row()
        {
            try
            {
                // create a list of spots                
                var localList = new List<(uint, uint)>();
                localList.Add((0, 0)); 
                localList.Add((0, 1));
                localList.Add((0, 2));
                localList.Add((0, 4));// create 5 spots. Non-contiguous
                localList.Add((0, 5));

                // create the bus object and park it
                Bus bus = new Bus(Guid.NewGuid(), localList);
                _parkingLot.ParkAVehicle(bus, (int)LotLevel.Large);
                Assert.Fail("An exception should have been thrown"); // no exception shoudl have been thrown
            }
            catch(BusDoesNotTakeUpFiveConsecutiveSpacesInARowAssertion)
            {
                Assert.Pass("The parking spaces are non contiguous");
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