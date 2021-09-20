using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.ProductApp.Pages
{
    public class Index_Tests : ProductAppWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
