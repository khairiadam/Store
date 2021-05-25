using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Store_API.Data;
using Store_API.Services.Categories;
using Store_APP.Services.Orders;
using Store_APP.Services.Products;
using Store_Shared.Models;

namespace Store_APP
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
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddCors();

            //!! Add DBContext ===>
            services.AddDbContext<AppDbContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("Adam"))
                    //option.UseSqlServer(Configuration.GetConnectionString("Omar"))
                    //option.UseSqlServer(Configuration.GetConnectionString("imad"))
                    //option.UseSqlServer(Configuration.GetConnectionString("Salma"))

                    );


            ////!! _ DependencyInjection _ ===>
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IUserService, UserService>();

            // services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store_APP", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store_APP v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}