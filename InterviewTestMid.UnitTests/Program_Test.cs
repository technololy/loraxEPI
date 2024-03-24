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
        }

        [Test]
        public void SampleData_WhenFindingFoil_ReturnFoilData()
        {
            subject = new(_logger.Object);

            Assert.That(subject.SampleFoilData?.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void SampleData_WhenUpdatingPartWeightValue_ReturnUpdatedData()
        {
            subject = new(_logger.Object);

            Assert.That(subject.SampleFoilData?.FirstOrDefault()?.PartWeight.Value, Is.Not.EqualTo(subject.SampleModifiedData?.PartWeight.Value));
        }
    }
}
