using AOP.API.Interceptors;
using AOP.API.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace AOP.API.Modeles
{
    public class RepoServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<LoggingInterceptor>();
            builder.RegisterType<CachingInterceptor>();
            builder.RegisterType<ProductService>().As<IProductService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InterceptedBy(typeof(CachingInterceptor));
            base.Load(builder);
        }
    }
}
