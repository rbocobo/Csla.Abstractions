using Csla.Abstractions.BusinessObjects.Contracts;
using Csla.Abstractions.BusinessObjects.Core.Contracts;

namespace Csla.Abstractions.UI
{
	public sealed class DependentPersonViewModel
	{
		public DependentPersonViewModel(IObjectFactory<IDependentPerson> personFactory)
		{
			this.Person = personFactory.Create();
		}

		public IDependentPerson Person { get; private set; }
	}
}
