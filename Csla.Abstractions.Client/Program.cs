using System;
using Autofac;
using Csla.Abstractions.BusinessObjects;
using Csla.Abstractions.BusinessObjects.Contracts;
using Csla.Abstractions.BusinessObjects.Core.Contracts;
using Csla.Abstractions.UI;

namespace Csla.Abstractions.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			//Program.UseObjectFactoryDirectly();
			Program.UseViewModel();
		}

		private static void UseObjectFactoryDirectly()
		{
			ApplicationContext.DataPortalActivator =
				new ObjectActivator(Program.CreateContainer());

			var person = new ObjectFactory<IPerson>().Create();
			person.Age = 40;
			person.Name = "Joe Smith";

			Console.Out.WriteLine("Name: " + person.Name);
			Console.Out.WriteLine("Age: " + person.Age);

			var dependentPerson = new ObjectFactory<IDependentPerson>().Create();
			dependentPerson.Age = 45;
			dependentPerson.Name = "Jane Smith";

			Console.Out.WriteLine("Dependent Name: " + dependentPerson.Name);
			Console.Out.WriteLine("Dependent Age: " + dependentPerson.Age);
		}

		private static void UseViewModel()
		{
			var container = Program.CreateContainer();

			ApplicationContext.DataPortalActivator =
				new ObjectActivator(container);

			using (var scope = container.BeginLifetimeScope())
			{
				var viewModel = scope.Resolve<DependentPersonViewModel>();
				viewModel.Person.Age = 45;
				viewModel.Person.Name = "Jane Smith";

				Console.Out.WriteLine("Dependent Name: " + viewModel.Person.Name);
				Console.Out.WriteLine("Dependent Age: " + viewModel.Person.Age);
			}
		}

		private static IContainer CreateContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterInstance<ILogger>(new Logger());
			builder.RegisterGeneric(typeof(ObjectFactory<>)).As(typeof(IObjectFactory<>));
			builder.RegisterType<DependentPersonViewModel>();

			return builder.Build();
		}
	}
}
