using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.ClaimsValueProvider
{
    /// <summary>
    /// A <see cref="IValueProviderFactory"/> that creates <see cref="IValueProvider"/> instances that read values from claims
    /// </summary>
    public class ClaimsValueProviderFactory : IValueProviderFactory
    {
        /// <inheritdoc />
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.ValueProviders.Add(new ClaimsValueProvider(ClaimsBindingSource.BindingSource, context.ActionContext.HttpContext.User));

            return TaskCache.CompletedTask;
        }
    }
}