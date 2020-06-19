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

namespace Mougnibas.LazyCook.WebAssembly
{
    using Microsoft.AspNetCore.Blazor.Hosting;

    /// <summary>
    /// ASP.NET Core entrypoint class.
    /// It simply serve web assembly static files.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Entry point method.
        /// </summary>
        public static void Main()
        {
            // ASP.NET Core related stuff.
            CreateHostBuilder().Build().Run();
        }

        /// <summary>
        /// ASP.NET Core related stuff.
        /// </summary>
        /// <returns>An ASP.NET Core related stuff.</returns>
        public static IWebAssemblyHostBuilder CreateHostBuilder() =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
