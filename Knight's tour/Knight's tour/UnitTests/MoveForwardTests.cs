using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Knight_s_tour
{
    [TestFixture]
    public class MoveForwardTests
    {
        #region feladat
        /*Az első teszt ellenőrzi, hogy a StepForward esemény kiváltódik e.
         *Második teszt ellenőrzi, hogy jó értékeket állít e be.
                Helyes értékek:
                			-aktuális hely   = az éppen most loggolt path utolsó elötti elem értékével.
                			-aktuális sor    = az aktuális hely osztva 8-al.
                			-aktuális oszlop = az aktuális hely maradékos osztás 8-al.
                            -útvonal 	     = jelenlegi útvonal plusz a végére fűzve az aktuális hely.
         */
        #endregion
        [Test]
        public void invokeStepForward_WhenCall_RaiseTheStepForwardEvent()
        {
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            string isSuccess = "No";
            calculator.getMoveObject.StepForward += (calc, e) => { isSuccess = "Yes"; };
            List<int> validSteps = new List<int> { 16, 18 };

            calculator.getMoveObject.invokeStepForward(calculator, new ForwardEventArgs(validSteps));


            Assert.That(isSuccess, Is.EqualTo("Yes"));
        }

        [Test]
        public void invokeStepForward_WhenCallinvokeStepForwardMethod_SetTheProperties()
        {
            Mock<IRoute> _route = new Mock<IRoute>();
            _route.Setup(r => r.GetPath).Returns(new List<int> { 1, 11, 21, 6 });
            Mock<ICalculatorIndexes> _indexes = new Mock<ICalculatorIndexes>();
            _indexes.Setup(s => s.ActualPosition).Returns(6);
            _indexes.Setup(s => s.ActualColumn).Returns(6);
            _indexes.Setup(s => s.ActualRow).Returns(0);

            Calculator _calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1, _route.Object, _indexes.Object);
            
            _calculator.getMoveObject.invokeStepForward(_calculator, new ForwardEventArgs(new List<int>
            {
                21,
                12,
                23
            }));
            int actualPositionAfterF = _calculator.getIndexes.ActualPosition;
            int rowIndexAfterF = _calculator.getIndexes.ActualRow;
            int columnIndexAfterF = _calculator.getIndexes.ActualColumn;
            List<int> pathAfterF = _calculator.getRoute.GetPath;
            bool isRightPath = pathAfterF.Count == 5 && pathAfterF[0] == 1 &&
                pathAfterF[1] == 11 && pathAfterF[2] == 21 && pathAfterF[3] == 6 &&
                (pathAfterF.Contains(21) || pathAfterF.Contains(12) || pathAfterF.Contains(23));

            Assert.That(actualPositionAfterF == pathAfterF[pathAfterF.Count - 1] &&
                        rowIndexAfterF == actualPositionAfterF / 8 &&
                        columnIndexAfterF == actualPositionAfterF % 8 &&
                        isRightPath);
        }
    }
}
