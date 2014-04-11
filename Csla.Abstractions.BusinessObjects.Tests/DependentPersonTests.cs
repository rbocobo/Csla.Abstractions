using Autofac;
using Csla.Abstractions.BusinessObjects.Contracts;
using Moq;
using Spackle.Extensions;
using Xunit;

namespace Csla.Abstractions.BusinessObjects.Tests
{
	public sealed class DependentPersonTests
	{
		[Fact]
		public void Create()
		{
			var logger = new Mock<ILogger>(MockBehavior.Strict);
			logger.Setup(_ => _.Log(It.IsAny<string>()));

			var builder = new ContainerBuilder();
			builder.Register<ILogger>(_ => logger.Object);

			using (new ObjectActivator(builder.Build()).Bind(() => ApplicationContext.DataPortalActivator))
			{
				var person = DataPortal.Create<DependentPerson>();
				logger.VerifyAll();
			}
		}
	}
}
