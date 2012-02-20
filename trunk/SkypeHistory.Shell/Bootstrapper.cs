using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using SkypeHistory.Infrastructure;
using SkypeHistory.Interfaces;
using SkypeHistory.Interfaces.Generators;
using SkypeHistory.Shell.Views;

namespace SkypeHistory.Shell
{
	public class Bootstrapper
	{
		private readonly UnityContainer container = new UnityContainer();

		public void Run()
		{
			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
			RegisterModules();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			RunShell();
		}

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.ExceptionObject.ToString());
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.ToString());
        }

		private void RunShell()
		{
            ProfileSelector selector = new ProfileSelector();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                var profileHolder = new ProfileHolder();
                profileHolder.Current = selector.CurrentProfile;
                container.RegisterInstance(typeof(IProfileHolder), profileHolder);

                Application.Run(container.Resolve<MainForm>());
            }
		}

		private void RegisterModules()
		{
			var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var baseType = typeof (BaseModule);

			var modulesList = new DirectoryInfo(dir).
				GetFiles("*.dll").
				Select(SafeLoadModule).
				Where(a => a.FullName.StartsWith("SkypeHistory")).
				Select(a =>
					a.GetExportedTypes().
					Where(t => !t.IsInterface && !t.IsAbstract && baseType.IsAssignableFrom(t)).
					Select(t => container.Resolve(t)).
					OfType<BaseModule>().
					ToList()).
				Where(l => l.Count != 0).
				ToList();
			foreach (var modules in modulesList)
			{
				foreach (var module in modules)
				{
					module.Run();					
				}
			}
		}

		private Assembly SafeLoadModule(FileInfo file)
		{
			try
			{
				return Assembly.LoadFile(file.FullName);
			}
			catch(BadImageFormatException ex)
			{
				throw new InvalidOperationException("Failed to load assembly " + file.FullName, ex);
			}
		}
	}
}