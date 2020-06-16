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

namespace Mougnibas.LazyCook.Recipes.Database
{
    /// <summary>
    /// A factory of recipe database.
    /// </summary>
    public class RecipeDatabaseFactory
    {
        /// <summary>
        /// Single RecipeDatabaseFactory instance.
        /// </summary>
        private static RecipeDatabaseFactory singleton;

        /// <summary>
        /// Recipe database instance.
        /// </summary>
        private RecipeDatabase recipeDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeDatabaseFactory"/> class.
        /// </summary>
        private RecipeDatabaseFactory()
        {
            this.recipeDatabase = new RecipeDatabase();
        }

        /// <summary>
        /// Get a (single) RecipeDatabaseFactory instance.
        /// </summary>
        /// <returns>
        /// Return a (single) RecipeDatabaseFactory instance.
        /// </returns>
        /// <remarks>
        /// This method is NOT thread safe, but it's ok.
        /// </remarks>
        public static RecipeDatabaseFactory Get()
        {
            if (singleton == null)
            {
                singleton = new RecipeDatabaseFactory();
            }

            return singleton;
        }

        /// <summary>
        /// Get a RecipeDatabase instance.
        /// </summary>
        /// <returns>
        /// Return a RecipeDatabase instance.
        /// </returns>
        public RecipeDatabase Make()
        {
            return this.recipeDatabase;
        }
    }
}
