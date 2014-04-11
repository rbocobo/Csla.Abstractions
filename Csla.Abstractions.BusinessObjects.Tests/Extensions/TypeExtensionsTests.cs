using System;
using Csla.Abstractions.BusinessObjects.Extensions;
using Csla.Abstractions.BusinessObjects.Tests.Extensions.Contracts;
using Xunit;

namespace Csla.Abstractions.BusinessObjects.Tests.Extensions
{
	public sealed class TypeExtensionsTests
	{
		[Fact]
		public void ConcreteFromInterface()
		{
			Assert.Equal(typeof(TestClass), typeof(ITestClass).GetConcreteType());
		}

		[Fact]
		public void ConcreteFromConcrete()
		{
			Assert.Equal(typeof(TestClass), typeof(TestClass).GetConcreteType());
		}

		[Fact]
		public void NullFromNull()
		{
			Assert.Null((null as Type).GetConcreteType());
		}
	}

	internal sealed class TestClass
		: ITestClass { }

	namespace Contracts
	{
		public interface ITestClass { }
	}
}
