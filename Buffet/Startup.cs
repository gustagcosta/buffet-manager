using Buffet.Data;
using Buffet.Models.Acesso;
using Buffet.Models.Usuario;
using Buffet.Models.SituacaoConvidado;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Buffet.Models.Evento;
using Buffet.Models.Cliente;
using Buffet.Models.Endereco;
using Buffet.Models.Local;

namespace Buffet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DatabaseContext>(options => options.UseMySql(Configuration.GetConnectionString("BuffetDB")));

            services.AddIdentity<Usuario, Papel>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 8;
                }
                ).AddEntityFrameworkStores<DatabaseContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Public/Login";
            });

            services.AddTransient<UsuarioService>();
            services.AddTransient<SituacaoConvidadoService>();
            services.AddTransient<SituacaoEventoService>();
            services.AddTransient<TipoEventoService>();
            services.AddTransient<AcessoService>();
            services.AddTransient<EventoService>();
            services.AddTransient<ClienteService>();
            services.AddTransient<LocalService>();
            services.AddTransient<EnderecoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Public/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Public}/{action=Index}/{id?}");
            });
        }
    }
}