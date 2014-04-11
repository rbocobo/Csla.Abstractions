using System;
using Csla.Abstractions.BusinessObjects.Contracts;
using Csla.Abstractions.BusinessObjects.Core;

namespace Csla.Abstractions.BusinessObjects
{
	[Serializable]
	internal sealed class Person
		: BusinessBaseCore<Person>, IPerson
	{
		public static readonly PropertyInfo<uint> AgeProperty =
			PropertyInfoRegistration.Register<Person, uint>(_ => _.Age);
		public uint Age
		{
			get { return this.GetProperty(Person.AgeProperty); }
			set { this.SetProperty(Person.AgeProperty, value); }
		}

		public static readonly PropertyInfo<string> NameProperty =
			PropertyInfoRegistration.Register<Person, string>(_ => _.Name);
		public string Name
		{
			get { return this.GetProperty(Person.NameProperty); }
			set { this.SetProperty(Person.NameProperty, value); }
		}
	}
}
