using System;

namespace ParkingLotLib
{
    public abstract class AbstractParkingLotSpotSpace
    {
        /// <summary>
        /// Each parking lot space is populated with a vehicle or part of a
        /// vehicle.
        /// </summary>
        public Guid VehicleUniqueIdenitifier { get; set; }
    }
}
