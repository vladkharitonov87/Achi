using Autofac;

namespace Achi.Data.Autofac
{
	public interface IInjectionConfiguration
	{
		IContainer Container { get; }
	}
}