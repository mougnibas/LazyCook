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
    /// RecipeDTO unit test class.
    /// </summary>
    [TestClass]
    public class RecipeDTOUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private RecipeDTO toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Name"/> property.
        /// </summary>
        [TestMethod]
        public void TestName()
        {
            string expected = "Velouté de patate douce";
            string actual = this.toTest.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.HumanTime"/> property.
        /// </summary>
        [TestMethod]
        public void TestHumanTime()
        {
            int expected = 15;
            int actual = this.toTest.HumanTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.MachineTime"/> property.
        /// </summary>
        [TestMethod]
        public void TestMachineTime()
        {
            int expected = 30;
            int actual = this.toTest.MachineTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionEqual()
        {
            RecipeStepDTO[] expected = new RecipeStepDTO[]
            {
                new RecipeStepDTO()
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
                },
            };
            RecipeStepDTO[] actual = this.toTest.Steps;
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnInstruction()
        {
            RecipeStepDTO[] unexpected = new RecipeStepDTO[]
            {
                new RecipeStepDTO()
                {
                    Instruction = "Peler la tomateeee",
                    Foods = new FoodDTO[]
                    {
                        new FoodDTO()
                        {
                            Name = "Tomato",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStepDTO[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnFoods()
        {
            RecipeStepDTO[] unexpected = new RecipeStepDTO[]
            {
                new RecipeStepDTO()
                {
                    Instruction = "Peler la tomate",
                    Foods = new FoodDTO[]
                    {
                        new FoodDTO()
                        {
                            Name = "Tomatooo",
                            Mass = 500,
                        },
                    },
                },
            };
            RecipeStepDTO[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Steps"/> property.
        /// </summary>
        [TestMethod]
        public void TestStepsCollectionNotEqualOnInstructionAndFoods()
        {
            RecipeStepDTO[] unexpected = new RecipeStepDTO[]
            {
                new RecipeStepDTO()
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
                },
            };
            RecipeStepDTO[] actual = this.toTest.Steps;
            CollectionAssert.AreNotEqual(unexpected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqualsReverse()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreEqual(recipe, this.toTest);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnName()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douceee",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHumanTime()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 150,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnMachineTime()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 300,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnSteps()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnEverything()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douceee",
                HumanTime = 150,
                MachineTime = 300,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            Assert.AreNotEqual(this.toTest, recipe);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsNullObject()
        {
            Assert.AreNotEqual(this.toTest, null);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnHack()
        {
            string hack = "RecipeDTO(Name='Velouté de patate douce', HumanTime='15, MachineTime='30, Steps='RecipeStepDTO(Instruction='Peler la tomate', Foods='FoodDTO(Name='Tomato', Mass='500')')')";
            Assert.AreNotEqual(this.toTest, hack);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void TestGetHashCode()
        {
            var recipe = new RecipeDTO()
            {
                Name = "Velouté de patate douce",
                HumanTime = 15,
                MachineTime = 30,
                Steps = new RecipeStepDTO[]
                {
                    new RecipeStepDTO()
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
                    },
                },
            };
            int expected = recipe.GetHashCode();
            int actual = this.toTest.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="RecipeDTO.ToString()"/> property.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "RecipeDTO(Name='Velouté de patate douce', HumanTime='15, MachineTime='30, Steps='RecipeStepDTO(Instruction='Peler la tomate', Foods='FoodDTO(Name='Tomato', Mass='500')')')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
