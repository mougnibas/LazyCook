// Copyright (c) 2019-2020 Yoann MOUGNIBAS
//
// This file is part of LazyCook.
//
// LazyCook is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// LazyCook is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with LazyCook.  If not, see <https://www.gnu.org/licenses/>.

namespace Mougnibas.LazyCook.Recipes.ContractTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.Recipes.Contract;

    /// <summary>
    /// Food unit test class.
    /// </summary>
    [TestClass]
    public class FoodUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private Food toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new Food()
            {
                Name = "Tomato",
                Mass = 500,
            };
        }

        /// <summary>
        /// Test <see cref="Food.Name"/> property.
        /// </summary>
        [TestMethod]
        public void TestName()
        {
            string expected = "Tomato";
            string actual = this.toTest.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Food.Mass"/> property.
        /// </summary>
        [TestMethod]
        public void TestMass()
        {
            int expected = 500;
            int actual = this.toTest.Mass;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            var tomato = new Food()
            {
                Name = "Tomato",
                Mass = 500,
            };
            Assert.AreEqual(this.toTest, tomato);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqualsReverse()
        {
            var tomato = new Food()
            {
                Name = "Tomato",
                Mass = 500,
            };
            Assert.AreEqual(tomato, this.toTest);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnName()
        {
            var tomato = new Food()
            {
                Name = "Tomatooo",
                Mass = 500,
            };
            Assert.AreNotEqual(this.toTest, tomato);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnMass()
        {
            var tomato = new Food()
            {
                Name = "Tomato",
                Mass = 50,
            };
            Assert.AreNotEqual(this.toTest, tomato);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnNameAndMass()
        {
            var tomato = new Food()
            {
                Name = "Tomatooo",
                Mass = 50,
            };
            Assert.AreNotEqual(this.toTest, tomato);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsNullObject()
        {
            Assert.AreNotEqual(this.toTest, null);
        }

        /// <summary>
        /// Test <see cref="Food.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHack()
        {
            string hack = "Food(Name='Tomato', Mass='500')";
            Assert.AreNotEqual(this.toTest, hack);
        }

        /// <summary>
        /// Test <see cref="Food.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void TestGetHashCode()
        {
            var tomato = new Food()
            {
                Name = "Tomato",
                Mass = 500,
            };
            int expected = tomato.GetHashCode();
            int actual = this.toTest.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Food.ToString()"/> method.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "Food(Name='Tomato', Mass='500')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
