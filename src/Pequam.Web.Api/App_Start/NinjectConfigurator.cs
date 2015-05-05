using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using Pequam.Common;
using Pequam.Common.Logging;
using Pequam.Common.Security;
using Pequam.Common.TypeMapping;
using Pequam.Data.QueryProcessors;
using Pequam.Data.SqlServer.Mapping;
using Pequam.Data.SqlServer.QueryProcessors;
using Pequam.Web.Api.AutoMappingConfiguration;
using Pequam.Web.Api.Controllers.V1;
//using Pequam.Web.Api.InquiryProcessing;
//using Pequam.Web.Api.LegacyProcessing;
//using Pequam.Web.Api.LegacyProcessing.ProcessingStrategies;
//using Pequam.Web.Api.LinkServices;
//using Pequam.Web.Api.MaintenanceProcessing;
//using Pequam.Web.Api.Security;
using Pequam.Web.Common;
using Pequam.Web.Common.Security;

namespace Pequam.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IAddChallengeQueryProcessor>().To<AddChallengeQueryProcessor>().InRequestScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<StatusEntityToStatusAutoMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<StatusToStatusEntityAutoMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<UserEntityToUserAutoMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<UserToUserEntityAutoMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<NewChallengeToChallengeEntityAutoMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<ChallengeEntityToChallengeAutoMapperTypeConfigurator>()
                .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<ChallengeToChallengeEntityAutoMapperTypeConfigurator>()
            //    .InSingletonScope();

            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<NewChallengeV2ToChallengeEntityAutoMapperTypeConfigurator>()
            //    .InRequestScope();
        }

        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        c => c.FromConnectionStringWithKey("PequamDb")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChallengeMap>())
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession);
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        }

        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return sessionFactory.GetCurrentSession();
        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }
    }
}