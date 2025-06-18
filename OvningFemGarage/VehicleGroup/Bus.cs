using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.VehicleGroup
{
    internal class Bus : Vehicle
    {
        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string fuelType) : base(registrationNumber, color, numberOfWheels, numberOfSeats, fuelType)
        {
        }
    }
}
