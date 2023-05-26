using Business.Contracts;
using Business.Implementation;
using Business.Services;
using Data;
using Data.Contracts;
using Data.Implementation;
using Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles; // Agregar esta referencia
using System.Web.Http;
using System.Web.Mvc;

namespace HeliBaja
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new Container();

            // Set the default scoped lifestyle
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register dependencies
            container.RegisterWebApiControllers(config);
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IAdminService, AdminService>();
            container.Register<IAdminRepository, AdminRepository>();
            container.Register<IPilotService, PilotService>();
            container.Register<IPilotRepository, PilotRepository>();
            container.Register<IClientService, ClientService>();
            container.Register<IClientRepository, ClientRepository>();
            container.Register<IInventoryService, InventoryService>();
            container.Register<IInventoryRepository, InventoryRepository>();
            container.Register<IFlightService, FlightService>();
            container.Register<IFlightRepository, FlightRepository>();
            container.Register<IAgendaService, AgendaService>();
            container.Register<IAgendaRepository, AgendaRepository>();
            container.Register<IBookingService, BookingService>();
            container.Register<IBookingRepository, BookingRepository>();
            container.Register<HeliBajaDBContext>(Lifestyle.Scoped);

            container.Verify();

            // Set the dependency resolver for Web API
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}