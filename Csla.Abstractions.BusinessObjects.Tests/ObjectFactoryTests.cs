using System;
using System.Threading.Tasks;
using Autofac;
using Csla.Abstractions.BusinessObjects.Tests.Contracts;
using Spackle;
using Xunit;

namespace Csla.Abstractions.BusinessObjects.Tests
{
	public sealed class ObjectFactoryTests
	{
		[Fact]
		public void BeginCreate()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginCreate());
		}

		[Fact]
		public void BeginCreateWithCriteria()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginCreate(null));
		}

		[Fact]
		public void BeginCreateWithCriteriaAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginCreate(null, null));
		}

		[Fact]
		public void BeginDeleteWithCriteria()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginDelete(null));
		}

		[Fact]
		public void BeginDeleteWithCriteriaAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginDelete(null, null));
		}

		[Fact]
		public void BeginExecuteWithObject()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginExecute(null));
		}

		[Fact]
		public void BeginExecuteWithObjectAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginExecute(null, null));
		}

		[Fact]
		public void BeginFetch()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginFetch());
		}

		[Fact]
		public void BeginFetchWithCriteria()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginFetch(null));
		}

		[Fact]
		public void BeginFetchWithCriteriaAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginFetch(null, null));
		}

		[Fact]
		public void BeginFetchWithObject()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginUpdate(null));
		}

		[Fact]
		public void BeginFetchWithObjectAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginUpdate(null, null));
		}

		[Fact]
		public void BeginUpdateWithObject()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginUpdate(null));
		}

		[Fact]
		public void BeginUpdateWithObjectAndUserState()
		{
			Assert.Throws<NotImplementedException>(
				() => new ObjectFactory<ObjectFactoryTest>().BeginUpdate(null, null));
		}

		[Fact]
		public void Create()
		{
			var test = new ObjectFactory<ObjectFactoryTest>().Create();
			Assert.Equal(string.Empty, test.Data);
		}

		[Fact]
		public void CreateWithCriteria()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			var test = new ObjectFactory<ObjectFactoryTest>().Create(data);
			Assert.Equal(data, test.Data);
		}

		[Fact]
		public async Task CreateAsync()
		{
			var test = await new ObjectFactory<ObjectFactoryTest>().CreateAsync();
			Assert.Equal(string.Empty, test.Data);
		}

		[Fact]
		public async Task CreateAsyncWithCriteria()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			var test = await new ObjectFactory<ObjectFactoryTest>().CreateAsync(data);
			Assert.Equal(data, test.Data);
		}

		[Fact]
		public void Delete()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			new ObjectFactory<ObjectFactoryTest>().Delete(data);
		}

		[Fact]
		public async Task DeleteAsync()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			await new ObjectFactory<ObjectFactoryTest>().DeleteAsync(data);
		}

		[Fact]
		public void Fetch()
		{
			var test = new ObjectFactory<ObjectFactoryTest>().Fetch();
			Assert.Equal(string.Empty, test.Data);
		}

		[Fact]
		public void FetchWithCriteria()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			var test = new ObjectFactory<ObjectFactoryTest>().Fetch(data);
			Assert.Equal(data, test.Data);
		}

		[Fact]
		public async Task FetchAsync()
		{
			var test = await new ObjectFactory<ObjectFactoryTest>().FetchAsync();
			Assert.Equal(string.Empty, test.Data);
		}

		[Fact]
		public async Task FetchAsyncWithCriteria()
		{
			var data = new RandomObjectGenerator().Generate<string>();
			var test = await new ObjectFactory<ObjectFactoryTest>().FetchAsync(data);
			Assert.Equal(data, test.Data);
		}

		[Fact]
		public void Execute()
		{
			var factory = new ObjectFactory<ObjectFactoryTestCommand>();
			var test = factory.Execute(factory.Create());
			Assert.Equal("done", test.Data);
		}

		[Fact]
		public async Task ExecuteAsync()
		{
			var factory = new ObjectFactory<ObjectFactoryTestCommand>();
			var test = await factory.ExecuteAsync(factory.Create());
			Assert.Equal("done", test.Data);
		}

		[Fact]
		public void GetGlobalContext()
		{
			var factory = new ObjectFactory<ObjectFactoryTestCommand>();
			Assert.Same(ApplicationContext.GlobalContext, factory.GlobalContext);
		}

		[Fact]
		public void Update()
		{
			var factory = new ObjectFactory<ObjectFactoryTest>();
			var test = factory.Fetch();
			factory.Update(test);
		}

		[Fact]
		public async Task UpdateAsync()
		{
			var factory = new ObjectFactory<ObjectFactoryTest>();
			var test = factory.Fetch();
			await factory.UpdateAsync(test);
		}
	}

	[Serializable]
	public sealed class ObjectFactoryTest
		: BusinessBase<ObjectFactoryTest>, IObjectFactoryTest
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
			PropertyInfoRegistration.Register<ObjectFactoryTest, string>(_ => _.Data);
		public string Data
		{
			get { return this.GetProperty(ObjectFactoryTest.DataProperty); }
			set { this.SetProperty(ObjectFactoryTest.DataProperty, value); }
		}
	}

	[Serializable]
	public sealed class ObjectFactoryTestCommand
		: CommandBase<ObjectFactoryTestCommand>, IObjectFactoryTestCommand
	{
		private void DataPortal_Create() { }

		protected override void DataPortal_Execute()
		{
			this.Data = "done";
		}

		public static PropertyInfo<string> DataProperty =
			PropertyInfoRegistration.Register<ObjectFactoryTestCommand, string>(_ => _.Data);
		public string Data
		{
			get { return this.ReadProperty(ObjectFactoryTestCommand.DataProperty); }
			set { this.LoadProperty(ObjectFactoryTestCommand.DataProperty, value); }
		}

		public ILifetimeScope Scope { get; set; }
	}

	namespace Contracts
	{
		public interface IObjectFactoryTest
			: IBusinessBase
		{
			string Data { get; set; }
		}

		public interface IObjectFactoryTestCommand
			: ICommandBase
		{
			string Data { get; set; }
		}
	}
}
