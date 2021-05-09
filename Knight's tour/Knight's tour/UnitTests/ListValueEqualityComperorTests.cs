using System.Collections.Generic;
using NUnit.Framework;

namespace Knight_s_tour
{
    [TestFixture]
    class ListValueEqualityComperorTests //két lista akkor egyenlő, ha pontosan ugyanazokat az inteket, ugyanabban a sorrendben tartalmazza.
    {
        #region feladat
        /*Első teszt ellenőrzi, hogy ha mindkét lista null, akkor egyenlő e.
         *Második teszt ellenőrzi, hogy ha egyik lista  null a másik meg egy inicializált, akkor egyenlő e.
         *Harmadik teszt ellenőrzi, hogy a különböző hosszúságú listák egyenlőek e.
         *Negyedik teszt ellenőrzi, hogy ugyanolyan hosszúságú, de más számokkal rendelkező lista ugyanaz e.
         *Ötödik teszt ellenőrzi, hogy két ugyanolyan listánál igazat ad e vissza.
         */
        #endregion

        [Test]
        public void Equals_NullLists_ReturnTrue()
        {
            ListValuesEqualityComparer comparer = new ListValuesEqualityComparer();
            List<int> x = null;
            List<int> y = null;

            bool result = comparer.Equals(x, y);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Equals_NullListAndNotNullList_ReturnTrue()
        {
            ListValuesEqualityComparer comparer = new ListValuesEqualityComparer();
            List<int> x = null;
            List<int> y = new List<int> { 51, 45, 748 };

            bool result = comparer.Equals(x, y);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Equals_CountsAreNotEqual_ReturnFalse()
        {
            ListValuesEqualityComparer comparer = new ListValuesEqualityComparer();
            List<int> x = new List<int> { 1, 5, 88, 99, 24, 34 };
            List<int> y = new List<int> { 51, 45, 748 };

            bool result = comparer.Equals(x, y);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Equals_NotSameList_ReturnFalse()
        {
            ListValuesEqualityComparer comparer = new ListValuesEqualityComparer();
            List<int> x = new List<int> { 1, 5, 88, 99, 24, 34 };
            List<int> y = new List<int> { 31, 45, 5, 67, 28, 3994 };

            bool result = comparer.Equals(x, y);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Equals_SameList_ReturnTrue()
        {
            ListValuesEqualityComparer comparer = new ListValuesEqualityComparer();
            List<int> x = new List<int> { 1, 5, 88, 99, 24, 34 };
            List<int> y = new List<int> { 1, 5, 88, 99, 24, 34 };

            bool result = comparer.Equals(x, y);

            Assert.That(result, Is.EqualTo(true));
        }
    }
}
