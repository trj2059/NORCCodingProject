using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public class ParkingLotLevelModel
    {
        public int ParkingLotLevel { get; set; }
        public List<AbstractParkingLotSpot> ParkingLotSpots { get; set; };
    }
}
