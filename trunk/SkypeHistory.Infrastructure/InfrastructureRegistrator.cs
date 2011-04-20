using System;
using System.Runtime.CompilerServices;
using SkypeHistory.Infrastructure.Generators.Html;
using SkypeHistory.Interfaces;
using Microsoft.Practices.Unity;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Infrastructure
{
	public class InfrastructureRegistrator : BaseModule
	{
		public override void Run()
		{
			Container.RegisterType<ISkypeService, SkypeService>();
		    Container.RegisterType<ITableWriter, TableWriter>();
		    Container.RegisterType<ICommonWriter, CommonWriter>();
		    Container.RegisterType<ICacheService, InMemoryCacheService>(new ContainerControlledLifetimeManager());
		}
	}
}