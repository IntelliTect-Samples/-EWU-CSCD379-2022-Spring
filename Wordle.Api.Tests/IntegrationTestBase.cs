using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api;

namespace Wordle.Api.Tests
{
    public class IntegrationTestBase
    {
        internal static HttpClient? _client;

        internal static HttpClient Client { get
            {
                if (_client == null)
                {
                    // Set up WebApplicationFactory
                    var factory = new WebApplicationFactory<Program>()
                        .WithWebHostBuilder(builder =>
                        {
                            builder.UseEnvironment("Development");
                        });
                    _client = factory.CreateClient();
                }
                return _client;
            }
        }
    }
}
