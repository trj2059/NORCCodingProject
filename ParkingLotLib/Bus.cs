using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public class Bus : AbstractVehicle
    {
        public Bus(Guid vuid, List<(uint,uint)> listOfSpacesVehicleTakesUp) 
            : base(vuid, listOfSpacesVehicleTakesUp)
        {

        }
    }
}
