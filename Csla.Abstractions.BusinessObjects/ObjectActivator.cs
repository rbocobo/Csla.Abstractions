using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Csla.Abstractions.BusinessObjects.Attributes;
using Csla.Abstractions.BusinessObjects.Core.Contracts;
using Csla.Abstractions.BusinessObjects.Extensions;
using Csla.Server;

namespace Csla.Abstractions.BusinessObjects
{
	public sealed class ObjectActivator
		: IDataPortalActivator
	{
		private IContainer container;

		public ObjectActivator(IContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			this.container = container;
		}

		public object CreateInstance(Type requestedType)
		{
			if (requestedType == null)
			{
				throw new ArgumentNullException("requestedType");
			}

			return Activator.CreateInstance(requestedType.GetConcreteType());
		}

		public void InitializeInstance(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}

			var scopedObject = obj as IBusinessScope;

			if (scopedObject != null)
			{
				var scope = this.container.BeginLifetimeScope();
				scopedObject.Scope = scope;

				foreach (var property in
					(from _ in scopedObject.GetType().GetProperties(
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
					 where _.GetCustomAttribute<DependencyAttribute>() != null
					 select _))
				{
					property.SetValue(scopedObject, scope.Resolve(property.PropertyType));
				}
			}
		}

		public void FinalizeInstance(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}

			var scopedObject = obj as IBusinessScope;

			if (scopedObject != null)
			{
				scopedObject.Scope.Dispose();

				foreach (var property in
					(from _ in scopedObject.GetType().GetProperties(
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
					 where _.GetCustomAttribute<DependencyAttribute>() != null
					 select _))
				{
					property.SetValue(scopedObject, null);
				}
			}
		}
	}
}
