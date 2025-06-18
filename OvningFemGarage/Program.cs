using OvningFemGarage.GarageLogic;
using OvningFemGarage.UI;
using OvningFemGarage.VehicleGroup;

namespace OvningFemGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello vehicle");

            var garage = new Garage<Vehicle>(10);// skapar 
            var handler = new GarageHandler(garage);

            handler.PopulateWithTestVehicles();
            var ui = new ConsoleUI(handler);

            ui.Run();

        }
    }
}
