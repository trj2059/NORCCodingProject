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
        /// The row and column of the first lot space that the vehicle taks up
        /// </summary>
        private List<(uint, uint)> _listOfSpacesTheVehicleTakesUp { get; set; }

        public AbstractVehicle(Guid vuid,List<(uint,uint)> listOfSpacesTheVehicleTakesUp)
        {
            _listOfSpacesTheVehicleTakesUp = listOfSpacesTheVehicleTakesUp;

            switch(this.GetType().Name)
            {
                case nameof(Motorcycle):
                    break;

            }
        }

        /// <summary>
        /// This roughly corresponds to the vin number of a vehicle
        /// </summary>
        public Guid VehicleUniqueIdenitifier { get; set; }
        
        
        
    }
}
