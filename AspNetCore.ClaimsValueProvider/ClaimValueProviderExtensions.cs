
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ClaimsValueProvider
{
    public static class ClaimsValueProviderExtensions
    {
        /// <summary>
        /// Register the <see cref="ClaimsValueProvider"/> with MVC
        /// </summary>
        public static void AddClaimsValueProvider(this MvcOptions options)
        {
            options.ValueProviderFactories.Add(new ClaimsValueProviderFactory());
        }
    }
}