using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AuctionManagement.Application;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Services;
using AuctionManagement.Infrastructure.ACL.Party;
using AuctionManagement.Interface.Facade;
using AuctionManagement.Interface.Facade.Contracts.Auctions.Services;
using AuctionManagement.Interface.Facade.Query;
using AuctionManagement.Interface.RestApi;
using AuctionManagement.Persistence.NH.Mappings;
using AuctionManagement.Persistence.NH.Repositories;
using AuctionManagement.QueryModel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application;
using Framework.Core;
using Framework.NH;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Configuration = NHibernate.Cfg.Configuration;

namespace AuctionManagement.Config
{
    public static class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            var sessionFactory = SessionFactoryBuilder.CreateByConnectionStringName("DBConnection", typeof(AuctionMapping).Assembly);

            container.Register(Classes.FromAssemblyContaining<AuctionsController>()
                .BasedOn<ApiController>().LifestylePerWebRequest());

            container.Register(Component.For<IAuctionService>()
                .ImplementedBy<AuctionService>().LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<AuctionCommandHandlers>()
                .BasedOn(typeof(ICommandHandler<>))
                .WithService.AllInterfaces().LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<AuctionRepository>()
                .BasedOn<IRepository>().WithService.FromInterface()
                .LifestylePerWebRequest());

            container.Register(Component.For<IParticipantService>()
                .ImplementedBy<PartyAclService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<QueryModelDb>().LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<AuctionFacadeService>()
                .BasedOn<IFacadeService>().WithService.FromInterface()
                .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<AuctionQueryFacade>()
                .BasedOn<IFacadeService>().WithService.FromInterface()
                .LifestylePerWebRequest());

            container.Register(Component.For<IDbConnection>()
                .UsingFactoryMethod(() =>
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    return connection;
                }).LifestylePerWebRequest().OnDestroy(a=>a.Close()));

            container.Register(Component.For<ISession>()
                .UsingFactoryMethod(a =>
                {
                    var connection = a.Resolve<IDbConnection>();
                    var session = sessionFactory.OpenSession(connection);
                    return session;
                }).LifestylePerWebRequest());
        }
     
    }
}
