using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public abstract class AbstractVehicle
    {
        /// <summary>
        /// This roughly corresponds to the vin number of a vehicle
        /// </summary>
        public Guid VehicleUniqueIdenitifier { get; set; }
        /// <summary>
        /// Indicates how many spaces the vehicle takes up.
        /// </summary>
        public SpacesEnum Spaces { get; set; }

    }
}
