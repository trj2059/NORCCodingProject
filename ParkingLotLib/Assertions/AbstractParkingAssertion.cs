using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib.Assertions
{
    /// <summary>
    /// A base assertion exception with the stack trace included in case the runtime doesn't include it.
    /// I believe this can happen in things like xamarin forms.  It also allows for easy filtering of assertions.
    /// </summary>
    public abstract class AbstractParkingAssertion : Exception
    {
        public AbstractParkingAssertion(string message)
            : base(message + "\n\n" + Environment.StackTrace) { }
    }
}
