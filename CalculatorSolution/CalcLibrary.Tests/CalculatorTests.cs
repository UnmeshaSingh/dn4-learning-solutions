using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
            TestContext.WriteLine("Setup Complete");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Test Finished");
        }

        [Test]
        public void Add_SimpleValues_ReturnsCorrectResult()
        {
            var result = _calc.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [TestCase(1, 2, 3)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Add_MultipleInputs_ReturnsExpected(int a, int b, int expected)
        {
            var result = _calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Subtraction test ignored for now.")]
        public void Subtract_SampleTest()
        {
            var result = _calc.Subtract(10, 5);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}
