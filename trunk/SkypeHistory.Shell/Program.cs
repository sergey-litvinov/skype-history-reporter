using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SkypeHistory.Infrastructure;

namespace SkypeHistory.Shell
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Bootstrapper bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
			StringBuilder builder = new StringBuilder();
			while (ex != null)
        	{
        		builder.AppendLine(ex.ToString());
        		ex = ex.InnerException;
				if (ex != null)
					builder.Append("Inner error:");
        	}
            MessageBox.Show("Error happens." + builder.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
	}
}
