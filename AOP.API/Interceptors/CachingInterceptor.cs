using AOP.API.Models;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;

namespace AOP.API.Interceptors
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly IMemoryCache _memoryCache;

        public CachingInterceptor(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            _memoryCache.Set("product:1", new Product() { Id = 1, Name = "Cache Pen 1", Price = 300 });
        }

        public void Intercept(IInvocation invocation)
        {

            var id = (int)invocation.Arguments.First();

            if (_memoryCache.TryGetValue<Product>($"product:{id}", out Product product))
            {
                invocation.ReturnValue = product;

            }
            else
            {
                invocation.Proceed();
            }


        }
    }
}
