using System;

namespace ParkingLotLib
{
    public class ParkingLotSpotSpace
    {
        /// <summary>
        /// Each parking lot space is populated with a vehicle or part of a
        /// vehicle.
        /// </summary>
        public Guid? VehicleUniqueIdenitifier { get; set; }

        /// <summary>
        /// If the VUID has a value, we know that there is at least part of a vehicle here
        /// </summary>
        public bool Populated {
            get
            {
                if (VehicleUniqueIdenitifier is Guid)
                    return true;
                else
                    return false;
            }
        }
    }
}
