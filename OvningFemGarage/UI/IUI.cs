using OvningFemGarage.VehicleGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.UI
{
    public interface IUI
    {
        void ShowMainMenu(); //visa huvudmeny
        string GetInput(string prompt); //få input från användare
        int GetMenuChoice(string prompt, int min, int max);//användaren väljer ett nummer mellan 1 och 5
        void ShowMessage(string message);//skriva ut ett meddelande
        bool Confirm(string prompt);

        void ShowAllVehicles(IEnumerable<Vehicle> vehicles);
        void ShowVehicleTypes(Dictionary<string, int> typeCounts);
        void ShowSearchResults(IEnumerable<Vehicle> results);

    }
}
