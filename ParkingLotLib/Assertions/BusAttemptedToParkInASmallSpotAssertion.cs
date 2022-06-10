using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib.Assertions
{
    /// <summary>
    /// Assertion to be caught if validation condition fails
    /// </summary>
    public class BusAttemptedToParkInASmallSpotAssertion : AbstractParkingAssertion
    {
        public BusAttemptedToParkInASmallSpotAssertion() : base("A bus tried to park in a small spot.")
        {

        }
    }
}
