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

namespace Mougnibas.LazyCook.WebAssembly.Test
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.LazyCook.WebAssembly.Test.Properties;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// WebAssembly end to end test class.
    /// </summary>
    [TestClass]
    public sealed class WebAssemblyEndToEndTest : IDisposable
    {
        /// <summary>
        /// Selenium web driver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// 'dotnet run' process.
        /// </summary>
        private Process processDotnetRun;

        /// <summary>
        /// Boolean to indicate is the application is started (in process 'dotnet run').
        /// </summary>
        private bool isApplicationStarted = false;

        /// <summary>
        /// Boolean to indicate is the server is in error state (in process 'dotnet run').
        /// </summary>
        private bool isServerError = false;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Create a new selenium web driver for an headless firefox instance
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            this.driver = new FirefoxDriver(options);

            // Find the webassembly directory
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo rootProjectDir = currentDir.Parent.Parent.Parent.Parent.Parent;
            DirectoryInfo srcProjectDir = rootProjectDir.GetDirectories("src")[0];
            string webassemblyProjectDir = null;
            foreach (DirectoryInfo di in srcProjectDir.GetDirectories())
            {
                if (di.Name.Equals("webassembly", StringComparison.Ordinal))
                {
                    webassemblyProjectDir = di.FullName;
                }
            }

            // If the webassembly project directory is not found, throw an exception
            if (webassemblyProjectDir == null)
            {
                throw new Exception(strings.ResourceManager.GetString("webassemblyNotFound", CultureInfo.InvariantCulture));
            }

            // Start a "dotnet run" process (spawning additional processes)
            this.processDotnetRun = new Process();
            this.processDotnetRun.StartInfo.FileName = "dotnet";
            this.processDotnetRun.StartInfo.Arguments = "run --project " + webassemblyProjectDir;
            this.processDotnetRun.StartInfo.UseShellExecute = false;
            this.processDotnetRun.StartInfo.RedirectStandardOutput = true;
            this.processDotnetRun.StartInfo.RedirectStandardError = true;
            this.processDotnetRun.Start();

            // Register sysin and sysout handler
            this.processDotnetRun.OutputDataReceived += new DataReceivedEventHandler(this.OutputDataHandler);
            this.processDotnetRun.ErrorDataReceived += new DataReceivedEventHandler(this.ErrorDataHandler);
            this.processDotnetRun.BeginOutputReadLine();
            this.processDotnetRun.BeginErrorReadLine();

            // Wait for the ASP.NET Kestrel program to publish the web application,
            // or until an error or a timeout occurs.
            int timeout = 30000;
            var max = DateTime.Now.AddMilliseconds(timeout);
            bool isTimeout = false;
            while (!this.isApplicationStarted && !this.isServerError && !isTimeout)
            {
                // Wait a little bit
                Thread.Sleep(500);

                // Is the timeout reached ?
                if (DateTime.Now >= max)
                {
                    isTimeout = true;
                }
            }

            // If there is a server error, throw an exception
            if (this.isServerError)
            {
                throw new Exception(strings.ResourceManager.GetString("serverSyserr", CultureInfo.InvariantCulture));
            }

            // If there is a server timeout error, throw an exception
            if (isTimeout)
            {
                throw new Exception(strings.ResourceManager.GetString("serverTimeout", CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Test the default recipe name.
        /// </summary>
        [TestMethod]
        public void TestIndexComponentDefaultRecipeName()
        {
            this.driver.Navigate().GoToUrl(new Uri("http://localhost:5000"));
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            IWebElement result = wait.Until(e => e.FindElement(By.Id("recipe-name")));

            string expected = "Velouté de patate douce et lentilles corail";
            string actual = result.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the "Velouté de patate douce et lentille corail" recipe name.
        /// </summary>
        [TestMethod]
        public void TestIndexComponentRecipeByParameterRecipeName()
        {
            this.driver.Navigate().GoToUrl(new Uri("http://localhost:5000/Velout%C3%A9%20de%20patate%20douce%20et%20lentilles%20corail"));
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            IWebElement result = wait.Until(e => e.FindElement(By.Id("recipe-name")));

            string expected = "Velouté de patate douce et lentilles corail";
            string actual = result.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the main layout, application part.
        /// </summary>
        [TestMethod]
        public void TestMainLayoutComponentApplication()
        {
            this.driver.Navigate().GoToUrl(new Uri("http://localhost:5000"));
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            IWebElement result = wait.Until(e => e.FindElement(By.Id("application")));

            IWebElement header = result.FindElement(By.Id("header"));
            IWebElement body = result.FindElement(By.Id("body"));
            IWebElement footer = result.FindElement(By.Id("footer"));

            Assert.IsNotNull(header);
            Assert.IsNotNull(body);
            Assert.IsNotNull(footer);
        }

        /// <summary>
        /// Test the default recipe human time.
        /// </summary>
        [TestMethod]
        public void TestDefaultRecipeHumanTime()
        {
            this.driver.Navigate().GoToUrl(new Uri("http://localhost:5000"));
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            IWebElement result = wait.Until(e => e.FindElement(By.Id("recipe-humantime")));

            string expected = "20";
            string actual = result.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the default recipe machine time.
        /// </summary>
        [TestMethod]
        public void TestDefaultRecipeMachineTime()
        {
            this.driver.Navigate().GoToUrl(new Uri("http://localhost:5000"));
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            IWebElement result = wait.Until(e => e.FindElement(By.Id("recipe-machinetime")));

            string expected = "27";
            string actual = result.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Invoke this method after each test method.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            // Ask selenium web driver to exit
            this.driver.Quit();

            // Kill the 'dotnet run' process and it's childs
            this.processDotnetRun.Kill(true);
            this.processDotnetRun.Close();
        }

        /// <summary>
        /// Free the eventually used 'dotnet run' process.
        /// </summary>
        public void Dispose()
        {
            // Dispose 'dotnet run' process
            if (this.processDotnetRun != null)
            {
                this.processDotnetRun.Dispose();
            }

            // Dispose selenium web driver
            if (this.driver != null)
            {
                this.driver.Dispose();
            }
        }

        /// <summary>
        /// Data ouput event handler of 'dotnet run' process.
        /// </summary>
        /// <param name="sendingProcess">Sending process object.</param>
        /// <param name="outLine">outLine event.</param>
        private void OutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string line = outLine.Data;
            if (!string.IsNullOrEmpty(line))
            {
                if (line.Contains("Application started.", StringComparison.Ordinal))
                {
                    this.isApplicationStarted = true;
                }

                Console.Out.WriteLine(line);
            }
        }

        /// <summary>
        /// Data error event handler of 'dotnet run' process.
        /// </summary>
        /// <param name="sendingProcess">Sending process object.</param>
        /// <param name="outLine">outLine event.</param>
        private void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            string line = outLine.Data;
            if (!string.IsNullOrEmpty(line))
            {
                this.isServerError = true;
                Console.Error.WriteLine(line);
            }
        }
    }
}
