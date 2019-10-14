﻿using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> _planes = new List<Plane>(){
           new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
           new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
           new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
           new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
           new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
           new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
           new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
           new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
           new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
           new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
           new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
           new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
   };

        private readonly PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
       
        private Airport _airport;

       [SetUp]
        public void Initialization()
        {
            _airport = new Airport(_planes);
        }

        private bool AreAllPlanesHaveMilitaryTransportType()
        {
            List<MilitaryPlane> transportMilitaryPlanes = _airport.GetTransportMilitaryPlanes();
            return transportMilitaryPlanes.All(type => type.PlaneTypeIs() == MilitaryType.TRANSPORT);
        }

        private bool IsSortByMaxLoadCapacityWorkCorrectly()
        {
            var sortedAirportList = _airport.SortByMaxLoadCapacity();
            for (var i = 0; i < sortedAirportList.Planes.Count - 1; i++)
            {
                var currentPlane = sortedAirportList.Planes[i];
                var nextPlane = sortedAirportList.Planes[i + 1];
                if (currentPlane._maxLoadCapacity > nextPlane._maxLoadCapacity)
                    return false;
            }
            return true;
        }

        [Test]
        public void AreAllPlanesHaveMilitaryTransportTypeTest()
        {
            Assert.IsTrue(AreAllPlanesHaveMilitaryTransportType());
        }

        [Test]
        public void ItIsPlaneWithMaxPassengerCapacity()
        {
            Assert.AreEqual(_airport.GetPassengerPlaneWithMaxPassengersCapacity(),_planeWithMaxPassengerCapacity);
        }

        [Test]
        public void IsSortByMaxLoadCapacityWorkCorrectlyTest()
        {
           Assert.IsTrue(IsSortByMaxLoadCapacityWorkCorrectly());
        }
    }
}