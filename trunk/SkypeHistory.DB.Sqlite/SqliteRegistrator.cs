using Microsoft.Practices.Unity;
using SkypeHistory.Interfaces;

namespace SkypeHistory.DB.Sqlite
{
	public class SqliteRegistrator : BaseModule
	{
		public override void Run()
		{
			Container.RegisterType<IChatRepository, SqliteChatRepository>();
			Container.RegisterType<ICallRepository, SqliteCallRepository>();
		}
	}
}