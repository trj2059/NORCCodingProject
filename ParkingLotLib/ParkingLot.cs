using ParkingLotLib.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    /// <summary>
    /// the parking lot is visualized has having multiple levels
    /// </summary>
    public class ParkingLot
    {
        private readonly List<ParkingLotLevel> _levels;

        public ParkingLot(List<ParkingLotLevel> levels)
        {
            _levels = levels;
        }

        /// <summary>
        /// Parks a vehicle in the garage.  Note that this is for only one space vehicles
        /// </summary>
        /// <param name="vehicle">The vehicle object we are parking</param>
        /// <param name="level">The level we are parking the on</param>
        /// <param name="space">the starting space we are parking in.</param>
        public void ParkAVehicle(AbstractVehicle vehicle, int level)
        {
            // attempting to park in a level that doesn't exist
            if (level > _levels.Count)
                throw new ParkingInNonExistantLevelAssertion();

            switch (vehicle)
            {
                case Motorcycle m:
                    {   
                        // verify that we are only taking up one space.
                        if (m.ListOfSpacesTheVehicleTakesUp.Count != 1)
                            throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();
                        
                        // the location of the motorcycle
                        (uint x, uint y) lotLocation = m.ListOfSpacesTheVehicleTakesUp[0];
                        
                        // get the parking garage level
                        ParkingLotLevel lotLevel = _levels[level];
                        
                        // we can park in any spot as a motorcycle so no assertion is necessary.

                        // populate the space.
                        lotLevel.ParkingLotSpots[lotLocation.x, lotLocation.y].VehicleUniqueIdenitifier = m.VehicleUniqueIdenitifier;
                    }
                    break;

                case Car c:
                    {
                        // verify that we are only taking up one space.
                        if (c.ListOfSpacesTheVehicleTakesUp.Count != 1)
                            throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();

                        // the location of the motorcycle
                        (uint x, uint y) lotLocation = c.ListOfSpacesTheVehicleTakesUp[0];

                        // get the parking garage level
                        ParkingLotLevel lotLevel = _levels[level];

                        if (lotLevel.ParkingLotSpots[lotLocation.x, lotLocation.y].spaceType == (SpotSpaceTypeEnum.Motorcycle))
                            throw new CarAttemptedToParkInAMotorCycleSpotAssertion();

                        // populate the space.
                        lotLevel.ParkingLotSpots[lotLocation.Item1, lotLocation.Item2].VehicleUniqueIdenitifier = c.VehicleUniqueIdenitifier;
                    }
                    break;

                case Bus b:
                    {
                        // get the parking garage level
                        ParkingLotLevel lotLevel = _levels[level];

                        // verify that we taking up five spaces.
                        if (b.ListOfSpacesTheVehicleTakesUp.Count != 5)
                            throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();

                        // if we are taking up 5 spaces, make sure that they are in a consecutive row.
                        if(b.ListOfSpacesTheVehicleTakesUp.Count == 5)
                            if (!b.DoesVehicleTakeUpFiveConsecutiveRowSpaces(_levels[level].ParkingLotSpots))
                                throw new BusDoesNotTakeUpFiveConsecutiveSpacesInARowAssertion();

                        // populate the spaces
                        foreach((uint x,uint y) location in b.ListOfSpacesTheVehicleTakesUp)
                        {
                            lotLevel.ParkingLotSpots[location.x, location.y].VehicleUniqueIdenitifier = b.VehicleUniqueIdenitifier;
                        }
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }

        }
    }
}

