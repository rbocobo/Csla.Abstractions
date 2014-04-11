using System;

namespace Csla.Abstractions.BusinessObjects.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DependencyAttribute
		: Attribute { }
}
