using Microsoft.AspNetCore.Mvc.Testing;
using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Context;
using NB.KingOfBeers.Database.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace NB.KingOfBeers.Api.IntegrationTests;

public class KobApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    public Mock<IGenericRepository<Beer>> BeerRepo { get; set; }

    public Mock<KobDataContext> KobDataContext { get; set; }

    public KobApplicationFactory()
        : base()
    {
        BeerRepo = new Mock<IGenericRepository<Beer>>();
        KobDataContext = new Mock<KobDataContext>();
    }


    protected override void ConfigureClient(HttpClient client)
    {
        base.ConfigureClient(client);

        client.BaseAddress = new Uri("https://localhost:5001");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.UseEnvironment(Environments.Production);

        builder.ConfigureAppConfiguration((context, configBuilder) =>
            {

                configBuilder.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["https_port"] = "",
                        ["OpenApi:UseXmlComments"] = "false",
                        ["CommonError:ExposeErrorDetail"] = "true"
                    });
            });
        builder.ConfigureTestServices(services =>
            {
                services.Replace(ServiceDescriptor.Singleton(BeerRepo.Object));
                services.Replace(ServiceDescriptor.Singleton(KobDataContext.Object));
            });
    }
}