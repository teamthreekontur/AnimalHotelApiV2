using AnimalHotelApi.Models;
using Models.Place.Repository;
using Models.User.Repository;
using MongoDB.Driver;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Web.Http;
using System.Xml.XPath;
using Unity;
using Unity.Lifetime;

namespace AnimalHotelApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
#if LOCAL
            container.RegisterSingleton<IUserRepository, MemoryUserRepository>();
            container.RegisterSingleton<IPlaceRepository, MemoryPlaceRepository>();
            container.RegisterSingleton<IAuthentificator, MemoryAuthentificator>();
            config.Routes.MapHttpRoute(
                name: "check",
                routeTemplate: "check",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "memory"));
#else
            MongoClientSettings settings = MongoClientSettings
                .FromUrl(new MongoUrl(ConfigurationManager.ConnectionStrings["AniHoDb"].ConnectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            container.RegisterSingleton<IUserRepository, DbUserRepository>();
            container.RegisterSingleton<IPlaceRepository, DbPlaceRepository>();
            container.RegisterSingleton<IAuthentificator, DbAuthentificator>();
            container.RegisterInstance<IMongoClient>(mongoClient);
            config.Routes.MapHttpRoute(
                name: "check",
                routeTemplate: "check",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "db"));
#endif

            config.DependencyResolver = new UnityResolver(container);

            // Attribute routing
            config.MapHttpAttributeRoutes();

            // Redirect root to Swagger UI
            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
