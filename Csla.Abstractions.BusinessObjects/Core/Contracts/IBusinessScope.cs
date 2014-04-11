using Autofac;

namespace Csla.Abstractions.BusinessObjects.Core.Contracts
{
	internal interface IBusinessScope
	{
		ILifetimeScope Scope { get; set; }
	}
}
