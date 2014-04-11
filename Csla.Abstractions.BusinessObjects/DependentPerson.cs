using System;
using Csla.Abstractions.BusinessObjects.Attributes;
using Csla.Abstractions.BusinessObjects.Contracts;
using Csla.Abstractions.BusinessObjects.Core;

namespace Csla.Abstractions.BusinessObjects
{
	[Serializable]
	internal sealed class DependentPerson
		: BusinessBaseScopeCore<DependentPerson>, IDependentPerson
	{
		protected override void DataPortal_Create()
		{
			base.DataPortal_Create();
			this.logger.Log("DataPortal_Create on DependentPerson invoked.");
		}

		public static readonly PropertyInfo<uint> AgeProperty =
			PropertyInfoRegistration.Register<DependentPerson, uint>(_ => _.Age);
		public uint Age
		{
			get { return this.GetProperty(DependentPerson.AgeProperty); }
			set { this.SetProperty(DependentPerson.AgeProperty, value); }
		}

		public static readonly PropertyInfo<string> NameProperty =
			PropertyInfoRegistration.Register<DependentPerson, string>(_ => _.Name);
		public string Name
		{
			get { return this.GetProperty(DependentPerson.NameProperty); }
			set { this.SetProperty(DependentPerson.NameProperty, value); }
		}

		[NonSerialized]
		private ILogger logger;
		[Dependency]
		internal ILogger Logger
		{
			private get { return this.logger; }
			set { this.logger = value; }
		}
	}
}
