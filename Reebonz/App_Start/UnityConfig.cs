using Reebonz.Dapper.Repository;
using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Service;
using Reebonz.Service.Interfaces;
using System;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Registration;

namespace Reebonz
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            //Register Service
            container.RegisterType<IRefundService, RefundService>();
            container.RegisterType<IOrderService, OrderService>();


            //Register Repository
            var ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            container.RegisterType<ISQLConnectionProvider, SQLConnectionProvider>(new InjectionConstructor(ConnectionString));
            container.RegisterType<IRefundRepository, RefundRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            

        }

        private static IUnityContainer _Container;

        private static IUnityContainer GetUnityContainer()
        {
            if (_Container == null)
            {
                _Container = new UnityContainer();
            }
            return _Container;
        }

        public static void RegisterTypes()
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            GetUnityContainer();

            //Register Service
            _Container.RegisterType<IRefundService, RefundService>();
            _Container.RegisterType<IOrderService, OrderService>();


            //Register Repository
            var ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            _Container.RegisterType<ISQLConnectionProvider, SQLConnectionProvider>(new InjectionConstructor(ConnectionString));
            _Container.RegisterType<IRefundRepository, RefundRepository>();

            //MVC Web
            DependencyResolver.SetResolver(new UnityDependencyResolver(_Container));
            //Web API
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi. UnityDependencyResolver(_Container);
        }
    }
}