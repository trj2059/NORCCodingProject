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
    public class BusAttemptedToParkInAnInvalidSpotAssertion : AbstractParkingAssertion
    {
        public BusAttemptedToParkInAnInvalidSpotAssertion() : base("A bus tried to park in an invalid spot.")
        {

        }
    }
}
