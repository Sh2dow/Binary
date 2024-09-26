using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using CoreExtensions.IO;
using CoreExtensions.Management;
using CoreExtensions.Native;
using Endscript.Core;
using Endscript.Enums;
using Endscript.Profiles;

namespace Binary
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool debugMode = false;

#if DEBUG
            debugMode = true;
#endif

            if (debugMode || e.Args.Length > 0)
            {
                NativeCallerX.AllocConsole();
            }

            if (e.Args.Length > 0)
            {
                var usage = eUsage.Invalid;

                usage = e.Args[0].ToLowerInvariant() switch
                {
                    "modder" => eUsage.Modder,
                    "user" => eUsage.User,
                    _ => throw new ArgumentException($"Invalid argument: {e.Args[0]} - \"user\" or \"modder\" expected."),
                };
                if (e.Args.Length < 2)
                {
                    throw new ArgumentException("Expected argument missing: VERSN1 path missing");
                }

                if (e.Args.Length < 3)
                {
                    throw new ArgumentException("Expected argument missing: VERSN2 path missing");
                }

                if (!File.Exists("MainLog.txt")) { using var str = File.Create("MainLog.txt"); }
                if (!File.Exists("EndError.log")) { using var str = File.Create("EndError.log"); }
                string pp = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                SetDependencyPaths(pp);

                var cli = new CLI();

                cli.LoadProfile(e.Args[1]);
                cli.ImportEndscript(e.Args[2]);
                cli.Save();

                Shutdown();
                return;
            }

            SetAppCulture();

            // Initialize WPF MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            if (debugMode)
            {
                NativeCallerX.FreeConsole();
            }
        }

        private static void SetDependencyPaths(string thispath)
        {
            string userdir = Path.Combine(thispath, "userkeys");
            string mainc = Path.Combine(thispath, @"mainkeys\carbon.txt");
            string userc = Path.Combine(thispath, @"userkeys\carbon.txt");
            // Repeat for other profiles...

            CarbonProfile.MainHashList = mainc;
            CarbonProfile.CustomHashList = userc;
            // Similar assignments for other profiles...

            if (!Directory.Exists(userdir))
            {
                _ = Directory.CreateDirectory(userdir);
            }

            if (!File.Exists(userc)) { _ = File.Create(userc); }
            // Repeat for other files...
        }

        private static void SetAppCulture()
        {
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Endscript.Version.Value = version;
            SynchronizedDatabase.Watermark = "Binary by MaxHwoy | Automated";

            if (!File.Exists("MainLog.txt")) { using var str = File.Create("MainLog.txt"); }
            if (!File.Exists("EndError.log")) { using var str = File.Create("EndError.log"); }
        }

        public static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            using var logger = new Logger("MainLog.txt", "Binary : Unknown Exception", true);
            logger.WriteException(e.Exception);

#if DEBUG
            MessageBox.Show("Unexpected error occurred. Please send MainLog.txt file to the developer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
#else
            MessageBox.Show($"Unexpected error occurred: {e.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
        }
    }
}
