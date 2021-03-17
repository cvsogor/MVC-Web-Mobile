using System.Collections.Generic;
using System.Linq;
using Interview.Controllers;
using NUnit.Framework;
using System.Web.Mvc;
using Interview.EF;

namespace Interview.Tests.Controllers
{
    [TestFixture]
    public class RangeControllerTest 
    {
        [Test]
        public void ListWrongName()
        {
            // Arrange
            RangeController controller = new RangeController();

            // Act
            ViewResult result = controller.List("~~@!#@%") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var manufacturers = result.Model as List<Manufacturer>;
            Assert.IsNotNull(manufacturers);
            Assert.IsTrue(manufacturers.Count == 0, "Manufacturers count should be 0");
        }

        [Test]
        public void ListManufacturer()
        {
            // Arrange
            RangeController controller = new RangeController();
            Entities db = new Entities();
            string manufacturerName = db.Manufacturer.First().ManufacturerName; 

            // Act
            ViewResult result = controller.List(manufacturerName) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var manufacturers = result.Model as List<Manufacturer>;
            Assert.IsNotNull(manufacturers);
            Assert.IsTrue(manufacturers.Count == 1, "Manufacturers count should be 1");
            Assert.IsTrue(manufacturers.First().ManufacturerName == manufacturerName, string.Format("Manufacturer name should be {0}", manufacturerName));
        }

        [Test]
        public void ListNull()
        {
            // Arrange
            RangeController controller = new RangeController();

            // Act
            ViewResult result = controller.List(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var manufacturers =  result.Model as List<Manufacturer>;
            Assert.IsNotNull(manufacturers);
            Assert.IsTrue(manufacturers.Count > 1, "Manufacturers count should be more than 1");
        }
    }
}
