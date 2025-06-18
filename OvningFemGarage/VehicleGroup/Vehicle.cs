using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ToDo: Detta är basklassen, skapa subklasser av fordon som kan ärva från denna. 
// registreringsnummer, ska vara unikt


namespace OvningFemGarage.VehicleGroup
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; } //unik identifierare
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int NumberOfSeats { get; set; }
        public string FuelType { get; set; }

        protected Vehicle(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string fuelType)
        {
            RegistrationNumber = registrationNumber.ToUpper(); // alltid versaler
            Color = color;
            NumberOfWheels = numberOfWheels;
            NumberOfSeats = numberOfSeats;
            FuelType = fuelType;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} - Registreringsnummer: {RegistrationNumber}, Färg: {Color}, Antal hjul: {NumberOfWheels}, Antal säten: {NumberOfSeats}, Drivmedelstyp: {FuelType}";
        }
    }
}
