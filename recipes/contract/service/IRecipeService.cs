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

namespace Mougnibas.LazyCook.Recipes.Contract.Service
{
    using Mougnibas.LazyCook.Recipes.Contract.DTO;

    /// <summary>
    /// Recipe service interface.
    /// </summary>
    public interface IRecipeService
    {
        /// <summary>
        /// Get all recipes.
        /// </summary>
        /// <returns>
        /// Return all recipes.
        /// </returns>
        public RecipeDTO[] GetAll();

        /// <summary>
        /// Get a recipe by name.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <returns>A recipe, or null if not found.</returns>
        public RecipeDTO GetByName(string name);
    }
}
