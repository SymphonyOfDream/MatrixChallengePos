using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixChallengePos.Services;
using MatrixChallengePos.ViewModels;
using MatrixChallengePos.Views;
using Ninject;

namespace MatrixChallengePos
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ensure the system comes up before presenting the GUI.
            try
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());

                var system = MatrixChallengePosSystem.Instance;

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(kernel.Get<MatrixChallengePosMainView>());
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show(e.ToString(), "Error Starting Up System", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                Console.WriteLine(e);
#endif
                throw;
            }
        }
    }
}
