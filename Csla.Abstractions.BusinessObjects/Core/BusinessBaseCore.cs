using System;
using Csla.Abstractions.BusinessObjects.Core.Contracts;

namespace Csla.Abstractions.BusinessObjects.Core
{
	[Serializable]
	internal abstract class BusinessBaseCore<T>
		: BusinessBase<T>, IBusinessBaseCore
		where T : BusinessBaseCore<T>
	{
		protected BusinessBaseCore()
			: base() { }
	}
}