using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace review
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
        {
            var c = builder.Build();

            // 从配置文件读取Nacos相关配置
            // 默认会使用JSON解析器来解析存在Nacos Server的配置
            builder.AddNacosV2Configuration(c.GetSection("NacosConfig"));
            // 也可以按需使用ini或yaml的解析器
            // builder.AddNacosConfiguration(c.GetSection("NacosConfig"), Nacos.IniParser.IniConfigurationStringParser.Instance);
            // builder.AddNacosConfiguration(c.GetSection("NacosConfig"), Nacos.YamlParser.YamlConfigurationStringParser.Instance);
        })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
