using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> planes = new List<Plane>(AddedPlanes.planes);
        private PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
        private List<Plane> PlanesOrderedByMaxLoadCapacity = AddedPlanes.planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList();

        [Test]
        public void CheckForTransportMilitaryPlanes()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();
            Assert.IsTrue(transportMilitaryPlanes.Count!=0);
        }

        [Test]
        public void TestingOfPlaneWithMaxPassengerCapacity()
        {
            Airport airport = new Airport(planes);
            PassengerPlane expectedPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(planeWithMaxPassengerCapacity));
        }

        [Test]
        public void TestingOfPlanesSortingByMaxLoadCapacity()
        {
            var airport = new Airport(planes);
            var expectedPlanesSortedByMaxLoadCapacity = airport.SortByMaxLoadCapacity().GetPlanes().ToList();
            Assert.IsTrue(expectedPlanesSortedByMaxLoadCapacity.SequenceEqual(PlanesOrderedByMaxLoadCapacity));
        }
    }
}
