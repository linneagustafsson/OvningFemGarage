using OvningFemGarage.VehicleGroup;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OvningFemGarage.GarageLogic
{
    public class GarageHandler
    {
        private readonly Garage<Vehicle> _garage;

        public GarageHandler(Garage<Vehicle> garage)
        {
            _garage = garage;
        }


        internal IEnumerable<Vehicle> GetAllVehicles()
        {
            return _garage;
        }

        internal Dictionary<string, int> GetVehicleTypeSummary()
        {
            return _garage.CountVehicleType();
        }

        internal bool ParkVehicle(Vehicle newVehicle)
        {
            return _garage.Add(newVehicle);
        }
        public Vehicle CreateVehicleViaUserInput()
        {
            Console.WriteLine("Välj fordonstyp:");
            Console.WriteLine("1. Flygplan");
            Console.WriteLine("2. Båt");
            Console.WriteLine("3. Buss");
            Console.WriteLine("4. Bil");
            Console.WriteLine("5. Motorcykel");
            Console.Write("Val: ");

            var typeChoice = Console.ReadLine();

            Console.Write("Registreringsnummer: ");
            string regNum;
            Regex regPattern = new Regex(@"^[A-Za-z]{3}[0-9]{3}$"); //

            do
            {
                Console.Write("Ange registreringsnummer (3 bokstäver + 3 siffror): ");
                regNum = Console.ReadLine()!.Trim().ToUpper();

                if (!regPattern.IsMatch(regNum))
                {
                    Console.WriteLine("❌ Ogiltigt format! Försök igen (exempel: ABC123)");
                }

            } while (!regPattern.IsMatch(regNum));



            string? color;
            int wheels;
            int seats;
            string? fuel;
            string? name;
            string? brand;

            switch (typeChoice)
            {
                case "1": // Flygplan
                    Console.Write("Färg: ");
                    color = Console.ReadLine()!.Trim();

                    Console.Write("Antal hjul: ");
                    int.TryParse(Console.ReadLine(), out wheels);

                    Console.Write("Antal säten: ");
                    int.TryParse(Console.ReadLine(), out seats);

                    Console.Write("Drivmedelstyp: ");
                    fuel = Console.ReadLine()!.Trim();

                    return new Airplane(regNum, color, wheels, seats, fuel);

                case "2": // Båt
                    Console.Write("Färg: ");
                    color = Console.ReadLine()!.Trim();

                    Console.Write("Antal hjul: ");
                    int.TryParse(Console.ReadLine(), out wheels);

                    Console.Write("Antal säten: ");
                    int.TryParse(Console.ReadLine(), out seats);

                    Console.Write("Drivmedelstyp: ");
                    fuel = Console.ReadLine()!.Trim();

                    Console.Write("Namn på båten: ");
                    name = Console.ReadLine()!.Trim();

                    return new Boat(regNum, color, wheels, seats, fuel, name);

                case "3": // Buss
                    Console.Write("Färg: ");
                    color = Console.ReadLine()!.Trim();

                    Console.Write("Antal hjul: ");
                    int.TryParse(Console.ReadLine(), out wheels);

                    Console.Write("Antal säten: ");
                    int.TryParse(Console.ReadLine(), out seats);

                    Console.Write("Drivmedelstyp: ");
                    fuel = Console.ReadLine()!.Trim();

                    return new Bus(regNum, color, wheels, seats, fuel);

                case "4": // Bil
                    Console.Write("Färg: ");
                    color = Console.ReadLine()!.Trim();

                    Console.Write("Antal hjul: ");
                    int.TryParse(Console.ReadLine(), out wheels);

                    Console.Write("Antal säten: ");
                    int.TryParse(Console.ReadLine(), out seats);

                    Console.Write("Drivmedelstyp: ");
                    fuel = Console.ReadLine()!.Trim();

                    Console.Write("Märke: ");
                    brand = Console.ReadLine()!.Trim();

                    return new Car(regNum, color, wheels, seats, fuel, brand);

                case "5": // Motorcykel
                    Console.Write("Färg: ");
                    color = Console.ReadLine()!.Trim();

                    Console.Write("Antal hjul: ");
                    int.TryParse(Console.ReadLine(), out wheels);

                    Console.Write("Antal säten: ");
                    int.TryParse(Console.ReadLine(), out seats);

                    Console.Write("Drivmedelstyp: ");
                    fuel = Console.ReadLine()!.Trim();

                    Console.Write("Märke: ");
                    brand = Console.ReadLine()!.Trim();

                    return new Motorcycle(regNum, color, wheels, seats, fuel, brand);

                default:
                    Console.WriteLine("Ogiltigt fordonstypval.");
                    return null!;
            }

        }

        internal bool RemoveVehicle(string regNum)
        {
            return _garage.Remove(regNum);
        }

        public IEnumerable<Vehicle> SearchVehiclesByUserInput()
        {
            Console.WriteLine("Sök fordon baserat på:");
            Console.WriteLine("1. Färg");
            Console.WriteLine("2. Antal hjul");
            //Console.WriteLine("3. Färg + Antal hjul");
            Console.Write("Val: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Skriv in färg du vill söka på: ");
                    var color = Console.ReadLine()?.ToLower();
                    var colorResult = _garage.Where (v => v.Color?.ToLower() == color);

                    Console.WriteLine($"Du sökte på färgen {color}");

                    if (!colorResult.Any()) //kontrollera om det finns fordon med den färgen
                    {
                        Console.WriteLine("Inga fordon hittades med den färgen.");
                    }
                    else
                    {
                        foreach (var v in colorResult)
                        {
                            Console.WriteLine(v);
                        }
                    }

                    break;

                    case "2":
                    Console.WriteLine("Skriv in antal hjul du vill söka på: ");
                    if (int.TryParse(Console.ReadLine(), out int wheels))
                    {
                        var wheelResult = _garage.Where(v => v.NumberOfWheels == wheels);

                        if (!wheelResult.Any())
                        {
                            Console.WriteLine("Inga fordon hittades med det antalet hjul.");
                        }
                        else
                        {
                            Console.WriteLine($"Du sökte på {wheels} hjul:");
                            foreach (var v in wheelResult)
                            {
                                Console.WriteLine(v);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Ogiltigt tal – försök igen.");
                    }
                    break;

                case "3":
                    Console.Write("Ange färg: ");
                    var colorResultCombined = Console.ReadLine()?.Trim().ToLower();

                    Console.Write("Ange antal hjul: ");
                    if (int.TryParse(Console.ReadLine(), out int wheelsResultCombined))
                    {
                        var resultCombined = _garage
                            .Where(v =>
                                v.Color?.ToLower() == colorResultCombined &&
                                v.NumberOfWheels == wheelsResultCombined);

                        if (!resultCombined.Any())
                        {
                            Console.WriteLine("Inga fordon matchade dina sökkriterier.");
                        }
                        else
                        {
                            Console.WriteLine($"Fordon med färg {colorResultCombined} och {wheelsResultCombined} hjul:");
                            foreach (var v in resultCombined)
                            {
                                Console.WriteLine(v);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Ogiltigt antal hjul.");
                    }
                    break;

            }
            return Enumerable.Empty<Vehicle>();
        }
        public void PopulateWithTestVehicles()
        {
            _garage.Add(new Car("ABC123", "Red", 4, 5, "Bensin", "Volvo"));
            _garage.Add(new Boat("DEF456", "Blue", 0, 6, "Diesel", "M/S Queen Mary"));
            _garage.Add(new Bus("XYZ789", "Yellow", 6, 20, "Diesel"));
            _garage.Add(new Motorcycle("MOT001", "Black", 2, 2, "HVO", "Kawasaki"));
        }
    }
}
