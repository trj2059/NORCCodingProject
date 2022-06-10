using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public class Car : AbstractVehicle
    {
        public Car(Guid vuid,List<(uint,uint)> listOfSpacesTheCarTakesUp) 
            : base(vuid, listOfSpacesTheCarTakesUp)
        {

        }
    }
}
