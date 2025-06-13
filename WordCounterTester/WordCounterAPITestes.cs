using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WordCounterAPI.Classes;
using Xunit;

namespace WordCounterTester
{
    public class WordCounterAPITestes : IClassFixture<WebApplicationFactory<WordCounterAPI.Program>>
    {
        private readonly HttpClient _client;

        public WordCounterAPITestes(WebApplicationFactory<WordCounterAPI.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task WordCounterAPI_FileSender_Test()
        {
            var file = "TestFile.txt";

            var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(file));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
            form.Add(fileContent, "textDocument", "TestFile.txt");

            var response = await _client.PostAsync("/api/wordcount", form);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var resultContent = JsonConvert.DeserializeObject<List<FoundWord>>(content);

            Xunit.Assert.Equal(13, resultContent.First(w => w.word == "Lorem").numberOfTimes);
        }
    }
}
