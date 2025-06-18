using OvningFemGarage.VehicleGroup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvningFemGarage.GarageLogic
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _vehicles; //array för fordonen
        private int _capacity;
        private int _count;//räknare

        public Garage(int capacity) 
        {
            _capacity = capacity;
            _vehicles = new T[_capacity];
            _count = 0;
        }

        public bool Add(T vehicle)
        {
            if (vehicle == null || _count >= _capacity)
                return false;

            for (int i = 0; i < _vehicles.Length; i++)
            {
                var v = _vehicles[i];

                if (v != null && v.RegistrationNumber.Equals(vehicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (v == null)
                {
                    _vehicles[i] = vehicle;
                    _count++;
                    return true;
                }
            }

            return false;
        }

        

        public bool Remove(string regNumber)
        {
            if (string.IsNullOrWhiteSpace(regNumber))
                return false;
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] != null &&
                    _vehicles[i].RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    _vehicles[i] = null!;
                    _count--;
                    return true;
                }
            }
            return false; // hittar inte 
        }

        public T? Find(string regNumber)
        {
            if (string.IsNullOrWhiteSpace(regNumber))
                return null;

            foreach (var vehicle in this)
            {
                if (vehicle.RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                    return vehicle;
            }

            return null; // inget matchande fordon hittades
        }
        public Dictionary<string, int> CountVehicleType()
        { 
        
            var typeCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var vehicle in _vehicles)
            {
                if (vehicle == null)
                    continue;

                var typeName = vehicle.GetType().Name;
                if (typeCounts.ContainsKey(typeName))
                    typeCounts[typeName]++;
                else
                    typeCounts[typeName] = 1;
            }
            return typeCounts;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
