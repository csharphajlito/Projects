using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace Knight_s_tour
{
    [TestFixture]
    public class StepServiceTests
    {
        #region feladat
        /*getTargetIndex:
         *  Az első kettő teszt jó eseteket ellenőriz.
         *  Második három tesztnél a túl kicsi indexeket ellenőrzőm.
         *  Harmadik három tesztnél a túl nagy indexeket ellenőrzőm.
         *
         *isInRange:
         *  első négynél tesztnél azt ellenőrzőm, hogy benne van e.
         *  
         *isInPath:
         *  első négynél tesztnél azt ellenőrzőm, hogy benne van e.
         *  
         *isLogged:
         *  első tesztnél azt ellenőrzőm, hogy egy nem loggolt kulcsnál mit add vissza.
         *  második tesztnél azt ellenőrzőm, hogy loggolt kulcsnál mit add vissza. (más érték esetében)
         *  harmadik tesztnél azt ellenőrzőm, hogy loggolt kulcsnál mit add vissza (egyező érték esetében)
         *  
         *stepping:
         *  első tesztnél azt ellenőrzőm, hogyha haveValidStep hamisat add vissza akkor kiváltódik e a Backtrack esemény.
         *  második tesztnél azt ellenőrzőm, hogyha haveValidStep igazat add vissza akkor kiváltódik e a StepForward esemény.
         */
        #endregion

        #region getTargetIndex

        [Test]
        //jó esetek
        [TestCase(2, 1, 17)]
        [TestCase(3, 6, 30)]
        //fölé,balra
        [TestCase(-2, 3, -1)]
        [TestCase(3, -1, -1)]
        [TestCase(-2, -1, -1)]
        //alá,jobbra
        [TestCase(8, 4, -1)]
        [TestCase(3, 9, -1)]
        [TestCase(8, 9, -1)]
        public void getTargetIndex_WhenCalled_ReturnsTheRightIndex(int x, int y, int expectedIndex)
        {
            StepService service = new StepService();

            int result = service.getTargetIndex(x, y);

            Assert.That(result, Is.EqualTo(expectedIndex));
        }
        #endregion

        #region isInRange

        [Test]
        [TestCase(0)]
        [TestCase(20)]
        public void isInRange_OutOfRangeCurrentField_ReturnFalse(int tempTargetIndex)
        {
            StepService service = new StepService();
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6, 7,
                                         8, 9, 10, 11, 12, 13, 14, 15};

            bool result = service.isInRange(currentFieldIndexes, tempTargetIndex);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase(4)]
        [TestCase(12)]
        public void isInRange_InRange_ReturnTrue(int tempTargetIndex)
        {
            StepService service = new StepService();
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6, 7,
                                         8, 9, 10, 11, 12, 13, 14, 15};

            bool result = service.isInRange(currentFieldIndexes, tempTargetIndex);

            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region isInPath

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        public void isInPath_OutOfRange_ReturnFalse(int tempTargetIndex)
        {
            StepService service = new StepService();
            List<int> path = new List<int> { 1, 16, 26, 20 };

            bool result = service.isInPath(tempTargetIndex, path);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase(16)]
        [TestCase(20)]
        public void isInPath_InRange_ReturnTrue(int tempTargetIndex)
        {
            StepService service = new StepService();
            List<int> path = new List<int> { 1, 16, 26, 20 };

            bool result = service.isInPath(tempTargetIndex, path);

            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region isLogged

        [Test]
        public void isLogged_NotLoggedPath_ReturnFalse()
        {
            StepService service = new StepService();
            var dictonary = new Dictionary<List<int>, List<int>>(new ListValuesEqualityComparer());
            dictonary.Add(new List<int> { 1, 16, 26 }, new List<int> { 11, 9 });
            dictonary.Add(new List<int> { 1, 18, 3 }, new List<int> { 13 });

            Mock<IBacktrackLogger> _logger = new Mock<IBacktrackLogger>();
            _logger.Setup(l => l.BacktracksContainer).Returns(dictonary);

            List<int> path = new List<int> { 1, 11, 21, 31 };
            int tempTargetIndex = 26;

            bool result = service.isLogged(_logger.Object, tempTargetIndex, path);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void isLogged_LoggedPathButNotLoggedValue_RetrunFalse()
        {
            StepService service = new StepService();
            var dictonary = new Dictionary<List<int>, List<int>>(new ListValuesEqualityComparer());
            dictonary.Add(new List<int> { 1, 16, 26 }, new List<int> { 11, 9 });
            dictonary.Add(new List<int> { 1, 18, 3 }, new List<int> { 13 });
            
            Mock<IBacktrackLogger> _logger = new Mock<IBacktrackLogger>();
            _logger.Setup(l => l.BacktracksContainer).Returns(dictonary);

            List<int> path = new List<int> { 1, 16, 26 };
            int tempTargetIndex = 20;

            bool result = service.isLogged(_logger.Object, tempTargetIndex, path);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void isLogged_LoggedPathAndLoggedValue_ReturnTrue()
        {
            StepService service = new StepService();
            //SetUp
            var dictonary = new Dictionary<List<int>, List<int>>(new ListValuesEqualityComparer());
            dictonary.Add(new List<int> { 1, 16, 26 }, new List<int> { 11, 9 });
            dictonary.Add(new List<int> { 1, 18, 3 }, new List<int> { 13 });
            //EndOfSetUp
            Mock<IBacktrackLogger> _logger = new Mock<IBacktrackLogger>();
            _logger.Setup(l => l.BacktracksContainer).Returns(dictonary);
            List<int> path = new List<int> { 1, 16, 26 };
            int tempTargetIndex = 11;


            bool result = service.isLogged(_logger.Object, tempTargetIndex, path);

            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region stepping
        [Test]
        public void stepping_haveBacktrack_InvokeBacktrackBacktrackEvent()
        {
            CalculatorIndexes indexes = new CalculatorIndexes();
            BacktrackLogger logger = new BacktrackLogger();
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6, 7,
                                         8, 9, 10, 11, 12, 13, 14, 15};
            List<int> path = new List<int> { 1, 16, 26 };
            MoveForward move = new MoveForward();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> validSteps = new List<int>();
            Mock<IValidStepCalculator> _validStepCalculator = new Mock<IValidStepCalculator>();
            _validStepCalculator.Setup(v => v.haveValidStep(It.IsAny<ICalculatorIndexes>(), It.IsAny<int[]>(), It.IsAny<List<int>>(),
                It.IsAny<IBacktrackLogger>(), It.IsAny<IStepService>(), out validSteps)).Returns(false);
            StepService service = new StepService(_validStepCalculator.Object);

            string isSuccess = "No";
            logger.Backtrack += (obj, e) => { isSuccess = "Yes"; };
            service.steping(indexes, currentFieldIndexes, path, logger, move, calculator);

            Assert.That(isSuccess, Is.EqualTo("Yes"));
        }

        [Test]
        public void stepping_NoBacktrack_InvokeMoveForwardEvent()
        {
            CalculatorIndexes indexes = new CalculatorIndexes();
            BacktrackLogger logger = new BacktrackLogger();
            int[] currentFieldIndexes = { 1, 2, 3, 4, 5, 6, 7,
                                         8, 9, 10, 11, 12, 13, 14, 15};
            List<int> path = new List<int> { 1, 16, 26 };
            MoveForward move = new MoveForward();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> validSteps = new List<int> { 18 };
            Mock<IValidStepCalculator> _validStepCalculator = new Mock<IValidStepCalculator>();
            _validStepCalculator.Setup(v => v.haveValidStep(It.IsAny<ICalculatorIndexes>(), It.IsAny<int[]>(), It.IsAny<List<int>>(),
                It.IsAny<IBacktrackLogger>(), It.IsAny<IStepService>(), out validSteps)).Returns(true);
            StepService service = new StepService(_validStepCalculator.Object);

            string isSuccess = "No";
            move.StepForward += (obj, e) => { isSuccess = "Yes"; };
            service.steping(indexes, currentFieldIndexes, path, logger, move, calculator);

            Assert.That(isSuccess, Is.EqualTo("Yes"));
        }
        #endregion
    }
}
