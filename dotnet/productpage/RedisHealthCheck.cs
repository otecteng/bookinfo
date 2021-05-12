using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
namespace productpage
{
    public class RedisHealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory _clientFactory;
        public RedisHealthCheck(IHttpClientFactory httpClientFactory)
        {
            this._clientFactory = httpClientFactory;
        }
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                IConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            }
            catch(Exception ex)
            {
                Console.WriteLine("redis health check exception:" + ex.ToString());
                return Task.FromResult(HealthCheckResult.Unhealthy("From redis"));
            }
            return Task.FromResult(HealthCheckResult.Healthy());
            
            
        }
    }
}