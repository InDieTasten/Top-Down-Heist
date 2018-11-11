using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalR;
using TopDownHeist.GameServer.Lobby;

namespace TopDownHeist.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddRazorViewEngine();

            services.AddSingleton<ILobbyManager, LobbyManager>();
            services.AddScoped<ILobbyContextAccessor, LobbyContextAccessor>();

            services.AddResponseCompression();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseSignalR(routes =>
            {
                routes.MapHub<HeistHub>("/heistHub");
                routes.MapHub<ChatHub>("/chathub");
            });

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
