using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    /// <summary>
    /// The parking lot level can be visualized as a 2 dimensional
    /// array of spots allowing rows and columns
    /// </summary>
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
