using Csla.Abstractions.BusinessObjects.Contracts;
using Csla.Abstractions.BusinessObjects.Core.Contracts;
using Moq;
using Xunit;

namespace Csla.Abstractions.UI.Tests
{
	public sealed class DependentPersonViewModelTests
	{
		[Fact]
		public void Create()
		{
			var person = Mock.Of<IDependentPerson>();

			var personFactory = new Mock<IObjectFactory<IDependentPerson>>(MockBehavior.Strict);
			personFactory.Setup(_ => _.Create()).Returns(person);

			var viewModel = new DependentPersonViewModel(personFactory.Object);

			Assert.Same(person, viewModel.Person);

			personFactory.VerifyAll();
		}
	}
}
