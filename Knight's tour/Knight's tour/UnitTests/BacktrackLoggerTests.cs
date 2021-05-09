using System.Collections.Generic;
using NUnit.Framework;

namespace Knight_s_tour
{
    [TestFixture]
    class BacktrackLoggerTests
    {
        #region feladat
        /*Első teszt ellenőrzi, hogy az invokeBacktrack metódus kiváltja e a Backtrackt eseményt.
         *Második teszt ellenőrzi, hogy egy új loggot helyesen tárol e az osztály.
         *Harmadik teszt ellenőrzi, hogy ha van két ugyanolyan kulcsú logg akkor helyesen tárolja e. 
            Helyes tárolás módja, hogy a már meglévő kulcs értékéhez fűzi hozzá a rossz útvonal indexét.
         *Negyedik teszt ellenőrzi, hogy a különböző kulcsú párokat külön esetben tárolja e el.
         *Ötödik teszt ellenőrzi, hogy az indexeket frissitő event kiváltódik e.
         *Hatodik teszt ellenőrzi, hogy jó értékeket kaptak e firssités után. 
            Helyes értékek:
                -aktuális hely   = az éppen most loggolt path utolsó elötti elem értékével
                -aktuális sor    = az aktuális hely osztva 8-al.
                -aktuális oszlop = az aktuális hely maradékos osztás 8-al.
         */
        #endregion

        #region Backtrack event tests
        [Test]
        public void invokeBacktrack_WhenCalledInvokeBacktrackMethod_RaiseBacktrackEvent()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            string isSuccess = "No";

            logger.Backtrack += (calc, e) => { isSuccess = "Yes"; };
            logger.invokeBacktrack(calculator, new StepBackEventArgs(new List<int> { 1, 18, 28 }));

            Assert.That(isSuccess, Is.EqualTo("Yes"));
        }

        [Test]
        public void BacktrackEvent_WhenRaiseTheBacktrackEvent_StoreTheRightPathAndTheRightValue()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> key = new List<int> { 1, 8, 28 };
            List<int> value = new List<int> { 11 };
            List<int> path = new List<int> { 1, 8, 28, 11 };
            //key: 1, 8, 28
            //value: 11

            logger.invokeBacktrack(calculator, new StepBackEventArgs(path));
            bool isOneCase = logger.BacktracksContainer.Count == 1;
            bool containsKey = logger.BacktracksContainer.ContainsKey(key);
            bool isRightValue = logger.BacktracksContainer[key][0] == value[0] &&
                logger.BacktracksContainer[key].Count == value.Count;

            Assert.That(isOneCase && containsKey && isRightValue);
        }

        [Test]
        public void BacktrackEvent_WhenRaiseTheBacktrackEventWithAnExistingPath_StoreInOneCase()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> path1 = new List<int> { 1, 8, 28, 11 };
            //key: 1, 8, 28
            //value: 11
            List<int> path2 = new List<int> { 1, 8, 28, 7 };
            //key: 1, 8, 28,
            //value: 7
            List<int> key = new List<int> { 1, 8, 28 };

            logger.invokeBacktrack(calculator, new StepBackEventArgs(path1));
            logger.invokeBacktrack(calculator, new StepBackEventArgs(path2));
            bool isOneCase = logger.BacktracksContainer.Count == 1;
            bool storiesTheRightValue = logger.BacktracksContainer[key].Count == 2 &&
                logger.BacktracksContainer[key].Contains(11) &&
                logger.BacktracksContainer[key].Contains(7);

            Assert.That(isOneCase && storiesTheRightValue);
        }

        [Test]
        public void BacktrackEvent_WhenRaiseTheBacktrackEventWhitANoneExistingPath()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> path1 = new List<int> { 1, 8, 28, 11 };
            List<int> key1 = new List<int> { 1, 8, 28 };
            //key: 1, 8, 28
            //value: 11
            List<int> path2 = new List<int> { 7, 22, 5, 20 };
            List<int> key2 = new List<int> { 7, 22, 5, };
            //key: 7, 22, 5,
            //value: 20


            logger.invokeBacktrack(calculator, new StepBackEventArgs(path1));
            logger.invokeBacktrack(calculator, new StepBackEventArgs(path2));

            bool isTwoCases = logger.BacktracksContainer.Count == 2;

            bool isContainedRigthCases = logger.BacktracksContainer.ContainsKey(key1) &&
                logger.BacktracksContainer.ContainsKey(key2);

            bool isRightValueKey1 = logger.BacktracksContainer[key1].Count == 1 &&
                logger.BacktracksContainer[key1][0] == 11;
            bool isRightValueKey2 = logger.BacktracksContainer[key2].Count == 1 &&
                logger.BacktracksContainer[key2][0] == 20;

            Assert.That(isTwoCases && isContainedRigthCases && isRightValueKey1 && isRightValueKey2);
        }

        #endregion

        #region RefreshIndexes event tests

        [Test]
        public void BacktrackEvent_WhenRaiseTheBacktrackEvent_CallSetMembersAfterBacktrackingPublicMethod()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            int actualPosition = calculator.getIndexes.ActualPosition;
            List<int> path = new List<int> { 1, 8, 28, 11 };
            //key: 1, 8, 28
            //value: 11

            logger.invokeBacktrack(calculator, new StepBackEventArgs(path));
            int afterBacktrackACtualPosition = calculator.getIndexes.ActualPosition;

            Assert.That(actualPosition != afterBacktrackACtualPosition);
        }

        [Test]
        public void BacktrackEvent_WhenRaiseTheBacktrackEvent_SetMembersAfterBacktrackingMethodSetActualPositionAndRowAndColumn()
        {
            BacktrackLogger logger = new BacktrackLogger();
            Calculator calculator = new Calculator(new FiveRowAndSixColumn().initializeChessTableComponent(), 1);
            List<int> path = new List<int> { 1, 8, 28, 11 };
            //key: 1, 8, 28
            //value: 11

            logger.invokeBacktrack(calculator, new StepBackEventArgs(path));
            int actualPositionAfterB = calculator.getIndexes.ActualPosition;
            int rowIndexAfterB = calculator.getIndexes.ActualRow;
            int columnIndexAfterB = calculator.getIndexes.ActualColumn;
            List<int> pathAfterB = calculator.getRoute.GetPath;
            bool isRightPath = pathAfterB[0] == 1 && pathAfterB[1] == 8 && pathAfterB[2] == 28 && pathAfterB.Count == 3;

            Assert.That(actualPositionAfterB == 28 &&
                        rowIndexAfterB == 28 / 8 &&
                        columnIndexAfterB == 28 % 8 &&
                        isRightPath);
        }

        #endregion
    }
}
