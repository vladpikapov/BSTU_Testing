using NUnit.Framework;

namespace TriangleTests
{
    public class TriangleTests
    {
        Triangle triangle = new Triangle();

        [Test]
        public void FirstSideIsNegative()
        {
            Assert.IsFalse(triangle.IsTriangle(-5, 1, 2));
        }

        [Test]
        public void SecondSideIsNegative()
        {
            Assert.IsFalse(triangle.IsTriangle(5, -2, 1));
        }

        [Test]
        public void ThirdSideIsNegative()
        {
            Assert.IsFalse(triangle.IsTriangle(10, 8, -5));
        }

        [Test]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(triangle.IsTriangle(-5, -6, -5));
        }

        [Test]
        public void AllSidesIsValid()
        {
            Assert.IsTrue(triangle.IsTriangle(10, 5, 6));
        }

        [Test]
        public void AllSideAreZero()
        {
            Assert.IsFalse(triangle.IsTriangle(0, 0, 0));
        }

        [Test]
        public void IsTriangleIsEquilateralTriangle()
        {
            Assert.IsTrue(triangle.IsTriangle(5, 5, 5));
        }
        
        [Test]
        public void IsTriangleIsIsoscelesTriangle()
        {
            Assert.IsTrue(triangle.IsTriangle(10, 10, 5));
        }

        [Test]
        public void IsTriangleIsNotValid()
        {
            Assert.IsFalse(triangle.IsTriangle(10,2,4));
        }

        [Test]
        public void OneSideEqualZero()
        {
            Assert.IsFalse(triangle.IsTriangle(0, 2, 5));
        }
    }
}