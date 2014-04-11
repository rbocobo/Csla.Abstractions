using Csla.Abstractions.BusinessObjects.Core.Contracts;
namespace Csla.Abstractions.BusinessObjects.Contracts
{
	public interface IPerson
		: IBusinessBaseCore
	{
		uint Age { get; set; }
		string Name { get; set; }
	}
}
