using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Wordle.Api.Tests
{
    internal class JsonContent: StringContent
    {
        public JsonContent(object model): base(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
        {

        }
    }
}
