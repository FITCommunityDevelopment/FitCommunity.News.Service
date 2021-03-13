using Geo.Database;
using Geo.GraphQL.Mutations;
using Geo.GraphQL.Queries;
using Geo.GraphQL.Subscriptions;
using Geo.GraphQL.Types;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Geo.GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<GeoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GeoDatabase")));

            services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<CityQueries>()
                    .AddTypeExtension<CountryQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<CityMutations>()
                    .AddTypeExtension<CountryMutations>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<CountrySubscriptions>()
                .AddType<CountryType>()
                .AddType<CityType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
