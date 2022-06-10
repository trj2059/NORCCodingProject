using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public class ParkingLotLevel
    {
        /// <summary>
        /// The parking lot spots are listed in [rows][columns]
        /// </summary>
        private ParkingLotSpotSpace[,] _parkingLotSpots;

        public ParkingLotLevel(int level,ParkingLotSpotSpace[,] spaces)
        {
            Level = level;
            _parkingLotSpots = spaces;
        }

        /// <summary>
        /// The level in the garage that the parking lot occupies.
        /// </summary>
        public int Level { get; set; }

       

    }
}
