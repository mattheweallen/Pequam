using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;
using System.Web.Http.ExceptionHandling;
using Pequam.Web.Common;
using Pequam.Web.Common.Routing;
using Pequam.Common.Logging;
using Pequam.Web.Common.ErrorHandling;


namespace Pequam.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof(IHttpControllerSelector),
                new NamespaceHttpControllerSelector(config));

            //config.EnableSystemDiagnosticsTracing(); //replaced by custom writer

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.Services.Replace(typeof(ITraceWriter),
                new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));

            config.Services.Add(typeof(IExceptionLogger),
                new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}
