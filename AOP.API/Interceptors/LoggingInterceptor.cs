using Castle.DynamicProxy;

namespace AOP.API.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        /// <inheritdoc />
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Executing {invocation.Method.Name} with parameters: " +
                              string.Join(", ", invocation.Arguments.Select(a => a?.ToString()).ToArray()));

            // Invoke the method
            invocation.Proceed();

            Console.WriteLine($"Finished executing {invocation.Method}");
        }
    }
}
