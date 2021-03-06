using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewFeatures
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ResetConnectionString();

            Application.Run(new Form1());
        }

        private static void ResetConnectionString()
        {
            string dbDir = GetDBDirectory() + @"\JSNorthWind.mdb";
            Properties.Settings.Default["JSNorthWindConnectionString"] = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbDir + ";";
        }
        private static string GetDBDirectory()
        {
            System.IO.DirectoryInfo currentDirectory = new System.IO.DirectoryInfo(Application.ExecutablePath).Parent;

            while (currentDirectory != null)
            {
                System.IO.DirectoryInfo[] childDirectories = currentDirectory.GetDirectories();
                foreach (System.IO.DirectoryInfo childDir in childDirectories)
                {
                    if (childDir.Name == "Data")
                    {
                        return childDir.FullName;
                    }
                }
                currentDirectory = currentDirectory.Parent;
            }
            return "";
        }


    }
}