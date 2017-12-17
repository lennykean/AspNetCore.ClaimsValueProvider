using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace AspNetCore.ClaimsValueProvider.Tests.Server
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options => options.ValueProviderFactories.Add(new ClaimsValueProviderFactory()))
                    .AddAuthorization()
                    .AddFormatterMappings()
                    .AddDataAnnotations()
                    .AddJsonFormatters()
                    .AddDataAnnotations();

            services.AddAuthentication(options => {
                        options.DefaultAuthenticateScheme = "TestAuth";
                        options.DefaultChallengeScheme = "TestAuth";
                    })
                    .AddScheme<AuthenticationSchemeOptions, AuthHandler>("TestAuth", "TestAuth", options => {
                        options.ClaimsIssuer = "TestAuth";
                    });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication()
               .UseMvc();
        }
    }
}
