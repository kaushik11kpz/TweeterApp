using com.tweetapp.Data;
using com.tweetapp.Data.IRepository;
using com.tweetapp.Mapper;
using com.tweetapp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.IO;
using System.Reflection;

namespace com.tweetapp
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
            services.AddSingleton<IMongoClient, MongoClient>(mongo => new MongoClient(Configuration.GetValue<string>("CosmosDbSettings:ConnectionStrings")));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITweetRepository, TweetRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITweetService, TweetService>();
            services.AddAutoMapper(typeof(UserDataMapper));
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("TweetAppAPI", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tweet App API",
                    Version = "1.0"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/TweetAppAPI/swagger.json", "Tweet App API");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
