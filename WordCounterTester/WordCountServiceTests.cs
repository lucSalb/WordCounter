using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterAPI.Services;
using Xunit;

namespace WordCounterTester
{
    public class WordCountServiceTests
    {
        [Fact]
        public void CountWordds_TEST()
        {
            var service = new WordCountService();

            var result = service.CountWords("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem dolor.");

            Xunit.Assert.Equal(2, result.First(w=>w.word == "Lorem").numberOfTimes);
            Xunit.Assert.Equal(1, result.First(w => w.word == "Ipsum").numberOfTimes);

        }
    }
}
