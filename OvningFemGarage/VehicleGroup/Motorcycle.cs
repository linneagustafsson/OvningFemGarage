using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.VehicleGroup
{
    internal class Motorcycle : Vehicle
    {
        public string Brand { get; set; }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string fuelType, string brand)
            : base(registrationNumber, color, numberOfWheels, numberOfSeats, fuelType)
        {
            Brand = brand;
        }

        public override string ToString()
        {
            return base.ToString() + $", Märke: {Brand}";
        }
    }
}
