namespace Achi.Data.Entities.Base
{
	public interface ITypedIdEntity<TId>
	{
		TId ID { get; set; }
	}
}
