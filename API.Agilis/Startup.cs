using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Agilis;
using Repository.Agilis.Repositories;
using Service.Agilis.Services;

namespace API.Agilis
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.Agilis", Version = "v1" });
            });

            // config NewtonsoftJson

            services.AddDbContext<AgilisDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ServerOnline"))
            );

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
            services.AddScoped(typeof(IProjectMemberRepository), typeof(ProjectMemberRepository));
            services.AddScoped(typeof(ISprintRepository), typeof(SprintRepository));
            services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddTransient(typeof(IMemberService), typeof(MemberService));
            services.AddTransient(typeof(IProjectService), typeof(ProjectService));
            services.AddTransient(typeof(IProjectMemberService), typeof(ProjectMemberService));
            services.AddTransient(typeof(ISprintService), typeof(SprintService));
            services.AddTransient(typeof(ITaskService), typeof(TaskService));
            services.AddTransient(typeof(IUserService), typeof(UserService));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.Agilis v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(x => x
                              .AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
