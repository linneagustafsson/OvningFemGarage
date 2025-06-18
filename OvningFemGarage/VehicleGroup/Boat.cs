using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OvningFemGarage.VehicleGroup
{
   
    public class Boat : Vehicle
    {
        public string Name { get; set; }
        public Boat(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string fuelType, string name)
            : base(registrationNumber, color, numberOfWheels, numberOfSeats, fuelType)
        {
            Name = name;
        }

        public override string ToString()
        {
            return base.ToString() + $", Name: {Name}";
        }
    }
}
