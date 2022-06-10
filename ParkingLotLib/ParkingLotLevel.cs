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
        public ParkingLotSpotSpace[,] ParkingLotSpots { get; set; }

        public ParkingLotLevel(int level,ParkingLotSpotSpace[,] spaces)
        {
            Level = level;
            ParkingLotSpots = spaces;
        }

        /// <summary>
        /// The level in the garage that the parking lot occupies.
        /// </summary>
        public int Level { get; set; }

       

    }
}
