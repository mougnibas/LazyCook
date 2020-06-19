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

namespace Mougnibas.LazyCook.Recipes.Contract.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.Recipes.Contract.DTO;

    /// <summary>
    /// RecipeStepDTO unit test class.
    /// </summary>
    [TestClass]
    public class RecipeStepDTOUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private RecipeStepDTO toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new RecipeStepDTO()
            {
                Instruction = "Peler la tomate",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomato",
                        Mass = 500,
                    },
                },
            };
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Instruction"/> property.
        /// </summary>
        [TestMethod]
        public void TestInstruction()
        {
            string expected = "Peler la tomate";
            string actual = this.toTest.Instruction;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Foods"/> property.
        /// </summary>
        [TestMethod]
        public void TestFoodsCollectionEqual()
        {
            FoodDTO[] expected = new FoodDTO[]
            {
                new FoodDTO()
                {
                    Name = "Tomato",
                    Mass = 500,
                },
            };
            FoodDTO[] actual = this.toTest.Foods;
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Foods"/> property.
        /// </summary>
        [TestMethod]
        public void TestFoodsCollectionNotEqualOnTomatoName()
        {
            FoodDTO[] unexpected = new FoodDTO[]
            {
                new FoodDTO()
                {
                    Name = "Tomatooo",
                    Mass = 500,
                },
            };
            FoodDTO[] actual = this.toTest.Foods;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Foods"/> property.
        /// </summary>
        [TestMethod]
        public void TestFoodsCollectionNotEqualOnTomatoMass()
        {
            FoodDTO[] unexpected = new FoodDTO[]
            {
                new FoodDTO()
                {
                    Name = "Tomato",
                    Mass = 5000,
                },
            };
            FoodDTO[] actual = this.toTest.Foods;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Foods"/> property.
        /// </summary>
        [TestMethod]
        public void TestFoodsCollectionNotEqualOnEmpty()
        {
            FoodDTO[] unexpected = Array.Empty<FoodDTO>();
            FoodDTO[] actual = this.toTest.Foods;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqual()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomate",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomato",
                        Mass = 500,
                    },
                },
            };
            Assert.AreEqual(this.toTest, recipeStep);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqualReverse()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomate",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomato",
                        Mass = 500,
                    },
                },
            };
            Assert.AreEqual(recipeStep, this.toTest);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnInstruction()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomateee",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomato",
                        Mass = 500,
                    },
                },
            };
            Assert.AreNotEqual(recipeStep, this.toTest);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnFoods()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomateee",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomatooo",
                        Mass = 500,
                    },
                },
            };
            Assert.AreNotEqual(recipeStep, this.toTest);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnInstructionAndFoods()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomateee",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomatooo",
                        Mass = 500,
                    },
                },
            };
            Assert.AreNotEqual(recipeStep, this.toTest);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsNullObject()
        {
            Assert.AreNotEqual(this.toTest, null);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHack()
        {
            string hack = "RecipeStepDTO(Instruction='Peler la tomate', Foods='FoodDTO(Name='Tomato', Mass='500')')";
            Assert.AreNotEqual(this.toTest, hack);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void TestGetHashCode()
        {
            var recipeStep = new RecipeStepDTO()
            {
                Instruction = "Peler la tomate",
                Foods = new FoodDTO[]
                {
                    new FoodDTO()
                    {
                        Name = "Tomato",
                        Mass = 500,
                    },
                },
            };
            int expected = recipeStep.GetHashCode();
            int actual = this.toTest.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeStepDTO.ToString()"/> property.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "RecipeStepDTO(Instruction='Peler la tomate', Foods='FoodDTO(Name='Tomato', Mass='500')')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
