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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text.Json;
    using Mougnibas.LazyCook.Recipes.Contract.DTO;
    using Mougnibas.LazyCook.Recipes.Contract.Service;

    /// <summary>
    /// A database of recipes.
    /// </summary>
    public class RecipeDatabase : IRecipeService
    {
        /// <summary>
        /// The list of recipes.
        /// </summary>
        private readonly Dictionary<string, RecipeDTO> recipes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeDatabase"/> class.
        /// </summary>
        public RecipeDatabase()
        {
            // Initialize the database.
            this.recipes = new Dictionary<string, RecipeDTO>();

            // Deserialize JSON recipe from assembly.
            var assembly = Assembly.GetExecutingAssembly();
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                // Only process json files.
                if (resourceName.EndsWith(".json", StringComparison.InvariantCulture))
                {
                    // Get a stream to the json file
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Deserialize the recipe.
                        var jsonString = reader.ReadToEnd();
                        var recipe = JsonSerializer.Deserialize<RecipeDTO>(jsonString);

                        // Add the recipe to the list of recipes.
                        this.recipes.Add(recipe.Name, recipe);
                    }
                }
            }
        }

        /// <summary>
        /// Get all recipes.
        /// </summary>
        /// <returns>
        /// Return all recipes.
        /// </returns>
        public RecipeDTO[] GetAll()
        {
            return new List<RecipeDTO>(this.recipes.Values).ToArray();
        }

        /// <summary>
        /// Get a recipe by name.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <returns>A recipe, or null if not found.</returns>
        public RecipeDTO GetByName(string name)
        {
            return this.recipes.ContainsKey(name) ? this.recipes[name] : null;
        }

        /// <summary>
        /// Return a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "RecipeDatabase(recipes.Count='{0}')", this.recipes.Count);
        }
    }
}
