using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Skol.Services.Seed;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

WebHost.CreateDefaultBuilder(args)

       .ConfigureServices((_, services) =>
       {
           services.AddApplication()
                   // .AddInfrastructure(_.Configuration)
                   .AddInfrastructure()
                   .AddApiVersioning(opts =>
                   {
                       opts.DefaultApiVersion = new ApiVersion(1, 0);
                       opts.AssumeDefaultVersionWhenUnspecified = true;
                       opts.ReportApiVersions = true;
                   })
                   .AddControllers(opts => opts.SuppressAsyncSuffixInActionNames = false);
       })

       .Configure(app =>
       {
           app.UseDeveloperExceptionPage()
              .UseHttpsRedirection()
              .UseRouting()
              .UseAuthorization()
              .UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              })
              .UseSeedData();
       })

       .Build()
       .Run();
