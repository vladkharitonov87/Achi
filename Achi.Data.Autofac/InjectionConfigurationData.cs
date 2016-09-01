using Achi.Data.Autofac.RegistrationModules;
using Autofac;

namespace Achi.Data.Autofac
{
	/// <summary>
	/// Configuration
	/// </summary>
	public class InjectionConfigurationData : IInjectionConfiguration
	{
		/// <summary>
		/// ContainerBuilder
		/// </summary>
		protected static ContainerBuilder ContainerBuilder { get; set; }

		/// <summary>
		/// container
		/// </summary>
		private IContainer container;

		protected static IInjectionConfiguration instance;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		protected InjectionConfigurationData()
		{

		}

		public static IInjectionConfiguration GetInstance()
		{
			if (instance == null)
			{
				ContainerBuilder = new ContainerBuilder();
				instance = new InjectionConfigurationData();
			}

			return instance;
		}

		/// <summary>
		/// Container
		/// </summary>
		public IContainer Container
		{
			get
			{
				if (container == null)
				{
					Initialize();
				}
				return container;
			}
		}

		/// <summary>
		/// RegisterTypes
		/// </summary>
		protected virtual void RegisterTypes()
		{
			ContainerBuilder.RegisterModule(new SqlRepositoryRegistrationModule());
		}

		/// <summary>
		/// Initialize
		/// </summary>
		protected virtual void Initialize()
		{

			RegisterTypes();
			container = ContainerBuilder.Build();
		}
	}
}
