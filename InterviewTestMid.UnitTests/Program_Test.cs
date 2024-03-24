using Moq;
using NUnit.Framework;

namespace InterviewTestMid.UnitTests
{
    public class Program_Test
    {
        private Program subject = default!;
        private Mock<ILogger> _logger = default!;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();

            subject = new(_logger.Object);
        }

        [Test]
        public void SampleData_WhenFindingFoil_ReturnFoilData()
        {
            Assert.That(subject.SampleFoilData?.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void SampleData_WhenUpdatingPartWeightValue_ReturnUpdatedData()
        {
            Assert.That(subject.SampleFoilData?.FirstOrDefault()?.PartWeight.Value, Is.Not.EqualTo(subject.SampleModifiedData?.PartWeight.Value));
        }
    }
}
