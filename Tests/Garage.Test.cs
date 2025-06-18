using OvningFemGarage.GarageLogic;
using OvningFemGarage.VehicleGroup;

namespace Tests
{
    public class GarageTest
    {
        [Fact]
        public void Add_ValidVehicle_ShouldBeAdded()
        {
            //arrange
            var garage = new Garage<Car>(5);
            var car = new Car("ABC123", "Röd", 4, 5, "Bensin", "Volvo");

            //act
            var wasAdded = garage.Add(car);

            //assert
            Assert.True(wasAdded);
            Assert.Contains(car, garage);
        }

        [Fact]
        public void Remove_Vehicle_ShouldBeRemoved()
        {
            //arrange
            var garage = new Garage<Car>(3);
            var car = new Car("ABC123", "Rosa", 4, 2, "Diesel", "Porsche");
            garage.Add(car);

            //act
            var wasRemoved = garage.Remove("ABC123");

            //assert
            Assert.True(wasRemoved);
            Assert.DoesNotContain(car, garage);
        }

        [Fact]
        public void Find_ExistingCar_ShouldReturnCar()
        {
            // Arrange
            var garage = new Garage<Car>(3);
            var car = new Car("XYZ456", "Svart", 4, 5, "El", "BMW");
            garage.Add(car);

            // Act
            var found = garage.Find("XYZ456");

            // Assert
            Assert.NotNull(found);
            Assert.Equal(car, found);
        }

        [Fact]
        public void Find_NonexistentCar_ShouldReturnNull() 
        {
            // Arrange
            var garage = new Garage<Car>(2);

            // Act
            var result = garage.Find("ZZZ999");

            // Assert
            Assert.Null(result);
        }


    }
}
