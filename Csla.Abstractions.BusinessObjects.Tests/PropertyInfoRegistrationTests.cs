using System;
using Spackle;
using Xunit;

namespace Csla.Abstractions.BusinessObjects.Tests
{
	public sealed class PropertyInfoRegistrationTests
	{
		[Fact]
		public void RegisterViaLambda()
		{
			var propertyInfo = PropertyInfoRegistration.Register<PropertyInfoRegistrationTest, string>(
				_ => _.LambdaTest);

			Assert.Equal("LambdaTest", propertyInfo.Name);
		}

		[Fact]
		public void RegisterViaLambdaAndRelationshipType()
		{
			var generator = new RandomObjectGenerator();
			var relationshipType = generator.Generate<RelationshipTypes>();

			var propertyInfo = PropertyInfoRegistration.Register<PropertyInfoRegistrationTest, string>(
				_ => _.LambdaAndRelationshipTypeTest, relationshipType);

			Assert.Equal("LambdaAndRelationshipTypeTest", propertyInfo.Name);
			Assert.Equal(relationshipType, propertyInfo.RelationshipType);
		}

		[Fact]
		public void RegisterViaName()
		{
			var generator = new RandomObjectGenerator();
			var name = generator.Generate<string>();

			var propertyInfo = PropertyInfoRegistration.Register<string>(
				typeof(PropertyInfoRegistrationTest), name);

			Assert.Equal(name, propertyInfo.Name);
		}

		[Serializable]
		private sealed class PropertyInfoRegistrationTest
			: BusinessBase<PropertyInfoRegistrationTest>
		{
			public string LambdaTest { get; set; }
			public string LambdaAndRelationshipTypeTest { get; set; }
		}
	}
}
