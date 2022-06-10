using ParkingLotLib.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public abstract class AbstractVehicle
    {
        /// <summary>
        /// The row and column of the first lot space that the vehicle takes up.
        /// We use unsigned ints because we are loading up these values into an array.
        /// </summary>
        public List<(uint x, uint y)> ListOfSpacesTheVehicleTakesUp { get; set; }

        /// <summary>
        /// This constructor runs validation logic when creating a new vehicle.
        /// </summary>
        /// <param name="vuid">The equivalent to a VIN number</param>
        /// <param name="listOfSpacesTheVehicleTakesUp">The spaces the vehicle is taking up.</param>
        public AbstractVehicle(Guid vuid,List<(uint,uint)> listOfSpacesTheVehicleTakesUp)
        {
            ListOfSpacesTheVehicleTakesUp = listOfSpacesTheVehicleTakesUp;
            if (ListOfSpacesTheVehicleTakesUp == null)
                throw new NullReferenceException();
            
            switch(this.GetType().Name)
            {
                case nameof(Motorcycle):
                    if (ListOfSpacesTheVehicleTakesUp.Count > 1 || ListOfSpacesTheVehicleTakesUp.Count == 0)
                        throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();
                    break;

                case nameof(Car):
                    if (ListOfSpacesTheVehicleTakesUp.Count > 1 || ListOfSpacesTheVehicleTakesUp.Count == 0)
                        throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();
                    break;

                case nameof(Bus):
                    if (ListOfSpacesTheVehicleTakesUp.Count == 0)
                        throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();
                    if (ListOfSpacesTheVehicleTakesUp.Count > 5)
                        throw new VehicleTakesUpAnInvalidNumberOfSpacesAssertion();
                    break;

                default:
                    throw new NotImplementedException();

            }
            
        }

        public bool DoesVehicleTakeUpFiveConsecutiveRowSpaces(ParkingLotSpotSpace[,] spaces)
        {
            if (ListOfSpacesTheVehicleTakesUp.Count != 5)
                return false;

            var initialSpot = ListOfSpacesTheVehicleTakesUp[0];
            uint initialRow = initialSpot.x;
            uint initialColumn = initialSpot.y;

            if (spaces[initialRow, initialColumn].spaceType != SpotSpaceTypeEnum.Large)
                throw new BusAttemptedToParkInAnInvalidSpotAssertion();

            uint currentRow = initialRow;
            uint currentColumn = initialColumn;

            // loop though all items that are not the inital location
            List<(uint x, uint y)> allButFIrstItem = ListOfSpacesTheVehicleTakesUp.Where(e => e.y != initialColumn).ToList();
            if (allButFIrstItem.Count == 0)
                throw new BusAttemptedToParkInAnInvalidSpotAssertion();

            foreach (var spot in allButFIrstItem)
            {
                if (spaces[spot.x, spot.y].spaceType != SpotSpaceTypeEnum.Large)
                    throw new BusAttemptedToParkInAnInvalidSpotAssertion();

                // we have hit a non consecutive item
                if (spot.y != currentColumn + 1)
                    return false;

                currentColumn = spot.y;
            }

            return true;
        }

        /// <summary>
        /// This roughly corresponds to the vin number of a vehicle
        /// </summary>
        public Guid VehicleUniqueIdenitifier { get; set; }

        public string VehicleType {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
