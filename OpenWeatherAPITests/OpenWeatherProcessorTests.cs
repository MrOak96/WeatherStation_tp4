using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        OpenWeatherProcessor _sut;

        [Fact]
        public async Task GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            _sut = OpenWeatherProcessor.Instance;
            _sut.ApiKey = null;
            //_sut.ApiKey = "";
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            _sut = OpenWeatherProcessor.Instance;
            _sut.ApiKey = null;
            //_sut.ApiKey = "";
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetCurrentWeatherAsync());
        }

        [Fact]
        public async Task GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            _sut = OpenWeatherProcessor.Instance;
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetOneCallAsync());
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            _sut = OpenWeatherProcessor.Instance;
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetCurrentWeatherAsync());
        }

    }
}
