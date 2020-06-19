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

namespace Mougnibas.LazyCook.Recipes.Database.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.Recipes.Database;

    /// <summary>
    /// RecipeDatabaseFactory unit test class.
    /// </summary>
    [TestClass]
    public class RecipeDatabaseFactoryUnitTest
    {
        /// <summary>
        /// Test the <see cref="RecipeDatabaseFactory.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetIsNotNull()
        {
            Assert.IsNotNull(RecipeDatabaseFactory.Get());
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabaseFactory.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestSameRecipeDatabaseFactoryInstance()
        {
            Assert.AreSame(RecipeDatabaseFactory.Get(), RecipeDatabaseFactory.Get());
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabaseFactory.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestMakeIsNotNull()
        {
            Assert.IsNotNull(RecipeDatabaseFactory.Get().Make());
        }

        /// <summary>
        /// Test the <see cref="RecipeDatabaseFactory.Get()"/> method.
        /// </summary>
        [TestMethod]
        public void TestSameRecipeDatabaseInstance()
        {
            Assert.AreSame(RecipeDatabaseFactory.Get().Make(), RecipeDatabaseFactory.Get().Make());
        }
    }
}
