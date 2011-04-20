using Microsoft.Practices.Unity;

namespace SkypeHistory.Interfaces
{
	public abstract class BaseModule
	{
		[Dependency]
		public IUnityContainer Container { get; set; }
		
		public abstract void Run();
	}
}