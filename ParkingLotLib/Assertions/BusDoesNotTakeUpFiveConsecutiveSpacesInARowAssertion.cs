using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib.Assertions
{
    public class BusDoesNotTakeUpFiveConsecutiveSpacesInARowAssertion : AbstractParkingAssertion
    {
        public BusDoesNotTakeUpFiveConsecutiveSpacesInARowAssertion() : base("A bus can is NOT parking in five large spots that are consecutive and within the same row")
        {

        }
    }
}
