using System;
using Autofac;
using Csla.Abstractions.BusinessObjects.Attributes;
using Csla.Abstractions.BusinessObjects.Core.Contracts;

namespace Csla.Abstractions.BusinessObjects.Core
{
	[Serializable]
	internal abstract class BusinessBaseScopeCore<T>
		: BusinessBaseCore<T>, IBusinessScope
		where T : BusinessBaseScopeCore<T>
	{
		protected BusinessBaseScopeCore()
			: base() { }

		[NonSerialized]
		private ILifetimeScope scope;
		[Dependency]
		ILifetimeScope IBusinessScope.Scope
		{
			get { return this.scope; }
			set { this.scope = value; }
		}
	}
}
