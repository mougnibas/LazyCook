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

namespace Mougnibas.LazyCook.Recipes.DatabaseTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.Recipes.Contract;
    using Mougnibas.LazyCook.Recipes.Database;

    /// <summary>
    /// RecipeDatabase unit test class.
    /// </summary>
    [TestClass]
    public class RecipeDatabaseUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private RecipeDatabase toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new RecipeDatabase();
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabase.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestArrayIsNotNull()
        {
            Recipe[] recipes = this.toTest.Get();
            Assert.IsNotNull(recipes);
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabase.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestArraySize()
        {
            int expected = 1;
            int actual = this.toTest.Get().Length;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabase.Get(string)"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetByNameVeloutePatateDouceLentilleCorail()
        {
            Recipe expected = new Recipe()
            {
                Name = "Velouté de patate douce et lentilles corail",
                HumanTime = 20,
                MachineTime = 27,
                Steps = new RecipeStep[]
                {
                    new RecipeStep()
                    {
                        Instruction = "Eplucher et couper la patate douce en morceau. Mettre de côté.",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Patate douce",
                                Mass = 400,
                            },
                        },
                    },
                    new RecipeStep()
                    {
                        Instruction = "Placer la lame 'Multi Blade'. Eplucher l'oignon, le couper en 4 et le mettre dans le bol. Fermer le bouchon. Pulse 10 secondes. Racler la parroi.",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Oignon",
                                Mass = 200,
                            },
                        },
                    },
                    new RecipeStep()
                    {
                        Instruction = "Mettre à porté de main le reste des ingrédients.",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Lentille corail",
                                Mass = 100,
                            },
                            new Food()
                            {
                                Name = "Curry en poudre",
                                Mass = 5,
                            },
                            new Food()
                            {
                                Name = "Purée de tomate",
                                Mass = 25,
                            },
                            new Food()
                            {
                                Name = "Lait de coco",
                                Mass = 150,
                            },
                            new Food()
                            {
                                Name = "Eau",
                                Mass = 500,
                            },
                        },
                    },
                    new RecipeStep()
                    {
                        Instruction = "Remplacer la lame 'Multi Blade' par le mélangeur 'Stir Assist'. Verser l'huile d'olive sur les oignons émincés. Ouvrir le bouchon. Température : 110°C, Durée : 2 minutes, Vitesse : Intermitante.",
                        Foods = new Food[]
                        {
                            new Food()
                            {
                                Name = "Huile d'olive",
                                Mass = 10,
                            },
                        },
                    },
                    new RecipeStep()
                    {
                        Instruction = "Remplacer le mélangeur 'Stir Assist' par la lame 'Multi Blade'. Ajouter tous les ingrédients mis de côté. Fermer le bouchon. Température : 100°C, Durée : 30 minutes, Vitesse : Intermitante.",
                        Foods = Array.Empty<Food>(),
                    },
                    new RecipeStep()
                    {
                        Instruction = "Température : 0°C, Durée : 2 minutes, Vitesse : Maximale.",
                        Foods = Array.Empty<Food>(),
                    },
                },
            };
            Recipe actual = this.toTest.Get("Velouté de patate douce et lentilles corail");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabase.Get(string)"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetByIsNull()
        {
           Assert.IsNull(this.toTest.Get("This recipe does not exist"));
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabase.ToString()"/> method.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "RecipeDatabase(recipes.Count='1')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
