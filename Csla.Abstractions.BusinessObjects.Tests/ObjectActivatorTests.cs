using System;
using Autofac;
using Csla.Abstractions.BusinessObjects.Tests.Contracts;
using Xunit;

namespace Csla.Abstractions.BusinessObjects.Tests
{
	public sealed class ObjectActivatorTests
	{
		private static void TestActivator(Action<IContainer> runTestCode)
		{
			runTestCode(new ContainerBuilder().Build());
		}

		[Fact]
		public void CreateActivatorWithNullContainer()
		{
			Assert.Throws<ArgumentNullException>(() => new ObjectActivator(null));
		}

		[Fact]
		public void CreateInstanceWhenRequestedTypeIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => ObjectActivatorTests.TestActivator(container =>
			{
				new ObjectActivator(container).CreateInstance(null);
			}));
		}

		[Fact]
		public void CreateInstanceWithInterfaceType()
		{
			ObjectActivatorTests.TestActivator(container =>
			{
				var activator = new ObjectActivator(container);
				var result = activator.CreateInstance(typeof(IActivatorTest));
				Assert.True(typeof(ActivatorTest).IsInstanceOfType(result));
			});
		}

		[Fact]
		public void CreateInstanceWithConcreteType()
		{
			ObjectActivatorTests.TestActivator(container =>
			{
				var activator = new ObjectActivator(container);
				var result = activator.CreateInstance(typeof(ActivatorTest));
				Assert.True(typeof(ActivatorTest).IsInstanceOfType(result));
			});
		}
	}

	[Serializable]
	public sealed class ActivatorTest
		: BusinessBase<ActivatorTest>, IActivatorTest
	{
		private void Child_Create(string data)
		{
			this.Data = data;
		}

		private void Child_Fetch(string data)
		{
			this.Data = data;
		}

		private void DataPortal_Create(string data)
		{
			this.Data = data;
		}

		private void DataPortal_Delete(string data)
		{
			this.Data = data;
		}

		private void DataPortal_Fetch(string data)
		{
			this.Data = data;
		}

		public static PropertyInfo<string> DataProperty =
			PropertyInfoRegistration.Register<ActivatorTest, string>(_ => _.Data);
		public string Data
		{
			get { return this.GetProperty(ActivatorTest.DataProperty); }
			set { this.SetProperty(ActivatorTest.DataProperty, value); }
		}
	}

	namespace Contracts
	{
		public interface IActivatorTest
			: IBusinessBase
		{
			string Data { get; set; }
		}
	}
}
