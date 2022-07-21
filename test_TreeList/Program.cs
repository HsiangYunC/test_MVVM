using System;
using System.Windows.Forms;

namespace Test_TreeList
{
    /// <summary>
    /// main program
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View());
        }
    }
}
