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
    class CarAttemptedToParkInAMotorCycleSpotAssertion : AbstractParkingAssertion
    {
        public CarAttemptedToParkInAMotorCycleSpotAssertion() : base("Car attempted to park in a motorcycle space.")
        {

        }
    }
}
