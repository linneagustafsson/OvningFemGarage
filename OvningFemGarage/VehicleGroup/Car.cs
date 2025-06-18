using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.VehicleGroup
{
    public class Car : Vehicle
    {
        public string Brand {  get; set; }

        public Car(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string fuelType, string brand)
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
