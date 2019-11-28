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
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.Recipes.Contract;

    /// <summary>
    /// Recipe unit test class.
    /// </summary>
    [TestClass]
    public class RecipeUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private Recipe toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
        }

        /// <summary>
        /// Test <see cref="Recipe.Name"/> property.
        /// </summary>
        [TestMethod]
        public void TestName()
        {
            string expected = "Velouté de patate douce";
            string actual = this.toTest.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.HumanTime"/> property.
        /// </summary>
        [TestMethod]
        public void TestHumanTime()
        {
            int expected = 15;
            int actual = this.toTest.HumanTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.MachineTime"/> property.
        /// </summary>
        [TestMethod]
        public void TestMachineTime()
        {
            int expected = 30;
            int actual = this.toTest.MachineTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionEqual()
        {
            RecipeStep[] expected = new RecipeStep[]
            {
                new RecipeStep()
                {
                    Instruction = "Peler la tomate",
                    Foods = new Food[]
                    {
                        new Food()
                        {
                            Name = "Tomato",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStep[] actual = this.toTest.Steps;
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnInstruction()
        {
            RecipeStep[] unexpected = new RecipeStep[]
            {
                new RecipeStep()
                {
                    Instruction = "Peler la tomateeee",
                    Foods = new Food[]
                    {
                        new Food()
                        {
                            Name = "Tomato",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStep[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnFoods()
        {
            RecipeStep[] unexpected = new RecipeStep[]
            {
                new RecipeStep()
                {
                    Instruction = "Peler la tomate",
                    Foods = new Food[]
                    {
                        new Food()
                        {
                            Name = "Tomatooo",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStep[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnInstructionAndFoods()
        {
            RecipeStep[] unexpected = new RecipeStep[]
            {
                new RecipeStep()
                {
                    Instruction = "Peler la tomateee",
                    Foods = new Food[]
                    {
                        new Food()
                        {
                            Name = "Tomatooo",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStep[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqualsReverse()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreEqual(recipe, this.toTest);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnName()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douceee",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHumanTime()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 150,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnMachineTime()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 300,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnSteps()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomateee",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnEverything()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douceee",
                HumanTime = 150,
                MachineTime = 300,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomateee",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsNullObject()
        {
            Assert.AreNotEqual(this.toTest, null);
        }

        /// <summary>
        /// Test <see cref="Recipe.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHack()
        {
            string hack = "Recipe(Name='Velouté de patate douce', HumanTime='15, MachineTime='30, Steps='RecipeStep(Instruction='Peler la tomate', Foods='Food(Name='Tomato', Mass='500')')')";
            Assert.AreNotEqual(this.toTest, hack);
        }

        /// <summary>
        /// Test <see cref="Recipe.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void TestGetHashCode()
        {
            var recipe = new Recipe()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Peler la tomate",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Tomato",
                                Mass = 500,
                            },
                        },
                    },
                },
            };
            int expected = recipe.GetHashCode();
            int actual = this.toTest.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Recipe.ToString()"/> property.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "Recipe(Name='Velouté de patate douce', HumanTime='15, MachineTime='30, Steps='RecipeStep(Instruction='Peler la tomate', Foods='Food(Name='Tomato', Mass='500')')')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
