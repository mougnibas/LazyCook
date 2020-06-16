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

namespace Mougnibas.LazyCook.Recipes.Contract.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// A recipe step class.
    /// </summary>
    public class RecipeStepDTO
    {
        /// <summary>
        /// Gets or sets the instruction.
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// Gets or sets the foods needed by this step.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "It's a DTO class.")]
        public FoodDTO[] Foods { get; set; }

        /// <summary>
        /// Check if the given object in parameter is equivalent to this one.
        /// </summary>
        /// <returns>
        ///     'true' if the given object in parameter is equivalent to this one,
        ///     'false' otherwise.
        /// </returns>
        /// <param name="obj">The object to compare from.</param>
        public override bool Equals(object obj)
        {
            return obj != null
                && obj is RecipeStepDTO
                && this.ToString().Equals(obj.ToString(), StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Return the hashcode of this object.
        /// </summary>
        /// <returns>the hashcode of this object.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode(StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Return a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "RecipeStepDTO(Instruction='{0}', Foods='{1}')",
                this.Instruction,
                string.Join<FoodDTO>(',', this.Foods));
        }
    }
}
