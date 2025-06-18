using OvningFemGarage.GarageLogic;
using OvningFemGarage.VehicleGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.UI
{
    public class ConsoleUI : IUI

    {
        private readonly GarageHandler _garageHandler;

        public ConsoleUI(GarageHandler handler)
        {
            _garageHandler = handler;
        }
        public void Run()
        {
            bool running = true;

            while (running)
            {
                ShowMainMenu();
                int choice = GetMenuChoice("Välj ett alternativ", 1,6);

                switch (choice)
                {
                    case 1:
                        var allVehicles = _garageHandler.GetAllVehicles();
                        ShowAllVehicles(allVehicles);
                        break;

                    case 2:
                        var newVehicle = _garageHandler.CreateVehicleViaUserInput();
                        if (_garageHandler.ParkVehicle(newVehicle))
                            ShowMessage("Fordonet har parkerats.");
                        else
                            ShowMessage("Misslyckades med att parkera fordonet.");
                        break;

                    case 3:
                        string? regNum = GetInput("Ange registreringsnummer att ta bort");
                        if (_garageHandler.RemoveVehicle(regNum))
                            ShowMessage("Fordonet togs bort.");
                        else
                            ShowMessage("Inget fordon hittades med det registreringsnumret.");
                        break;

                    case 4:
                        var result = _garageHandler.SearchVehiclesByUserInput();
                       
                        ShowSearchResults(result);
                        break;

                    case 5:
                        var typeSummary = _garageHandler.GetVehicleTypeSummary();
                        ShowVehicleTypes(typeSummary);

                        break;

                    case 6:
                        if (Confirm("Vill du verkligen avsluta? j = ja, n = nej"))
                            running = false;
                        break;
                }

                Console.WriteLine();
            }
        }
        public bool Confirm(string prompt)
        {
            Console.Write($"{prompt} (j/n): ");
            var input = Console.ReadLine();
            return input?.Trim().ToLower() == "j";

        }

        public string? GetInput(string prompt)
        {

            string? input;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine()?.Trim();
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;

        }

        public int GetMenuChoice(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{prompt} [{min}-{max}]: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                    return choice;

                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }

        public void ShowAllVehicles(IEnumerable<Vehicle> vehicles)
        {
            Console.WriteLine("=== Parkerade fordon ===");
            var list = vehicles.ToList();
            Console.WriteLine($"Totalt: {list.Count} fordon");
            foreach (var v in list)
            {
                Console.WriteLine(v);
            }

        }

        public void ShowMainMenu()
        {
            Console.WriteLine("=== Garage 1.0 ===");
            Console.WriteLine("1. Visa alla fordon");
            Console.WriteLine("2. Parkera fordon");
            Console.WriteLine("3. Ta ut fordon");
            Console.WriteLine("4. Sök fordon");
            Console.WriteLine("5. Visa fordonstyper");
            Console.WriteLine("6.Avsluta");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);

        }

        public void ShowSearchResults(IEnumerable<Vehicle> results)
        {
            Console.WriteLine("=== Sökresultat ===");
            foreach (var v in results)
            {
                Console.WriteLine(v);
            }

        }

        public void ShowVehicleTypes(Dictionary<string, int> typeCounts)
        {
            Console.WriteLine("=== Fordonstyper i garaget ===");
            foreach (var kvp in typeCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} st");
            }

        }
    }

}
