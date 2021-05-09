using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Knight_s_tour
{
    [TestFixture]
    public class ValidStepCalculatorTests
    {
        #region feladat
        /*Egyenként elszeparálva egymástól a függvények műkődnek és ebben a két példában konkrét esetett ellenerzők.
         */
        #endregion


        [Test]
        public void haveValidStep_ConcrateComplexExample1()
        {
            CalculatorIndexes indexes = new CalculatorIndexes
            {
                ActualPosition = 11,
                ActualRow = 2,
                ActualColumn = 3,
                TempTargetIndex = 28,
            };
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6, 7,
                                         8, 9, 10, 11, 12, 13, 14, 15,
                                         16, 17, 18, 19, 20, 21, 22, 23,
                                         24, 25, 26, 27, 28, 29, 30, 31};
            List<int> path = new List<int> { 1, 8, 28, 11 };
            BacktrackLogger logger = new BacktrackLogger();
            Mock<IStepService> _service = new Mock<IStepService>();
            _service.Setup(s => s.getTargetIndex(It.IsAny<int>(), It.IsAny<int>())).Returns(-1);
            ValidStepCalculator validStepCalculator = new ValidStepCalculator();
            List<int> validSteps;

            bool result = validStepCalculator.haveValidStep(indexes, currentFieldIndexes, path, logger, _service.Object, out validSteps);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(validSteps.Count == 0);
        }

        [Test]
        public void haveValidStep_ConcrateComplexExample2()
        {
            CalculatorIndexes indexes = new CalculatorIndexes
            {
                ActualPosition = 13,
                ActualRow = 1,
                ActualColumn = 5,
                TempTargetIndex = 28,
            };
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6,
                                         8, 9, 10, 11, 12, 13, 14, 15,
                                         16, 17, 18, 19, 20, 21, 22, 23,
                                         24, 25, 26, 27, 28, 29, 30, 31};
            List<int> path = new List<int> { 18, 24, 9, 19, 25, 10, 27, 17, 11, 5, 20, 3, 13 };
            Dictionary<List<int>, List<int>> dictonary = new Dictionary<List<int>, List<int>>(new ListValuesEqualityComparer());
            dictonary.Add(new List<int> { 18, 24, 9, 19, 25, 10, 27, 17, 11, 5, 20, 3, 13 },
                new List<int> { 7, 3, 28, 30, }); // csak a 23 hiányzik(19 ott ban a path-ban a maradék a táblán kivülre esik)
            Mock<IBacktrackLogger> _logger = new Mock<IBacktrackLogger>();
            _logger.Setup(l => l.BacktracksContainer).Returns(dictonary);
            ValidStepCalculator validStepCalculator = new ValidStepCalculator();
            List<int> validSteps = new List<int>();

            bool result = validStepCalculator.haveValidStep(indexes, currentFieldIndexes,
                path, _logger.Object, new StepService(), out validSteps);

            Assert.That(validSteps[0] == 23);
        }
    }
}
