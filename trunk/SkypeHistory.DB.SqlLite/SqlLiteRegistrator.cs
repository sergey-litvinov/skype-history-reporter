using Microsoft.Practices.Unity;
using SkypeHistory.Interfaces;

namespace SkypeHistory.DB.SqlLite
{
	public class SqlLiteRegistrator : BaseModule
	{
		public override void Run()
		{
			Container.RegisterType<IChatRepository, SqlLiteChatRepository>();
		}
	}
}