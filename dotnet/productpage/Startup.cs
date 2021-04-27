using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Elastic.Apm.NetCoreAll;
using IdentityModel;
using Nacos.AspNetCore.V2;
using Nacos.V2.DependencyInjection;
namespace productpage
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
            services.AddHttpClient();
            var key = "pandasandalbuggybrokenrock";
            services.AddAuthentication("Basic").
                AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic",null);
            services.AddSingleton<ICustomAuthenticationManager, CustomAuthenticationManager>();
            //services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            //===bearer token相关配置开始===
            
            // services.AddAuthentication(x =>
            // {
            //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer(x =>
            // {
            //     x.RequireHttpsMetadata = false;
            //     x.SaveToken = true;
            //     x.TokenValidationParameters = new TokenValidationParameters
            //     {                    
            //         ValidateIssuerSigningKey = true,//是否调用对签名securityToken的SecurityKey进行验证
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.Secret)),//签名秘钥
            //         ValidateIssuer = true,//是否验证颁发者
            //         ValidIssuer = JwtSettings.Issuer, //颁发者
            //         ValidateAudience = true, //是否验证接收者
            //         ValidAudience = JwtSettings.Audience,//接收者
            //         ValidateLifetime = true,//是否验证失效时间
            //     };
            // });
            
            //===bearer token相关配置结束===
            //===Nacos相关配置===
            services.AddNacosAspNetCore(Configuration);
            services.AddNacosV2Naming(x =>
            {
                x.ServerAddresses = new System.Collections.Generic.List<string> { "http://localhost:8848/" };
                x.EndPoint = "";
                // swich to use http or rpc
                x.NamingUseRpc = true;
            });
            //===Nacos相关配置结束===
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseAllElasticApm(Configuration);
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                app.UseAllElasticApm(Configuration);
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
