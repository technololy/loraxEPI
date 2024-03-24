using InterviewTestMid.Data;
using Moq;
using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            _logger.Setup(x => x.WriteLogMessage(It.IsAny<string>()));
            _logger.Setup(x => x.WriteErrorMessage(It.IsAny<Exception>()));

            subject = new(_logger.Object);
        }

        [Test]
        public void SampleData_WhenFindingFoil_EnsureFoilData()
        {
            Assert.That(subject.SampleFoilData?.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void SampleData_WhenUpdatingPartWeightValue_EnsureUpdatedData()
        {
            Assert.That(subject.SampleFoilData?.FirstOrDefault()?.PartWeight.Value, Is.Not.EqualTo(subject.SampleModifiedData?.PartWeight.Value));
        }

        [Test]
        public void SampleData_CheckMetaObjectsInEachPart_EnsureCountInEachPart()
        {
            if (subject.SampleFoilData == null)
            {
                return;
            }
            foreach (SampleDataModel data in subject.SampleFoilData)
            {
                Assert.That(data.Meta, Is.Not.Null);
            }

            foreach (SampleDataModel data in subject.SampleFoilData)
            {
                Assert.That(data.Meta.CountNumberOfMetaObjects(), Is.EqualTo(4));
            }
        }
    }
}
