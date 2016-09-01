using Achi.Data.Entities.SQL;
using Achi.Data.SQL;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;
using Autofac;

namespace Achi.Data.Autofac.RegistrationModules
{
	public class SqlRepositoryRegistrationModule : Module
	{
		/// <summary>
		/// Load
		/// </summary>
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AchiDbContext>().AsSelf();
			builder.RegisterType<AchiUnitOfWork>().As<IQueryableUnitOfWork>().InstancePerLifetimeScope();

			builder.RegisterType<SqlRepositoryFactory>().As<IRepositoryFactory>().SingleInstance();
		}
	}
}
