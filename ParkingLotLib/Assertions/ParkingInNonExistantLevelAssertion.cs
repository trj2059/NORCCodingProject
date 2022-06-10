using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib.Assertions
{
    public class ParkingInNonExistantLevelAssertion : AbstractParkingAssertion
    {
        public ParkingInNonExistantLevelAssertion() : base("Attempted to park in a non existant level")
        {

        }
    }
}
