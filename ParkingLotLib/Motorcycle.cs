﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLib
{
    public class Motorcycle : AbstractVehicle
    {
        public Motorcycle(Guid guid,List<(uint,uint)> listOfSpacesMotorcycleTakesUp) : base(guid, listOfSpacesMotorcycleTakesUp)
        {

        }
    }
}
