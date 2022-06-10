using ParkingLotLib.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
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
        public void ParkAVehicle(AbstractVehicle vehicle, uint level)
        {
            // attempting to park in a level that doesn't exist
            if (level > _levels.Count)
                throw new ParkingInNonExistantLevelAssertion();

            switch (vehicle)
            {
                case Motorcycle m:
                    break;

                case Car c:
                    break;

                default:
                    throw new NotImplementedException();
            }

        }
    }
}
