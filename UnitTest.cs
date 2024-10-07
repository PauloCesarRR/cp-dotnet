using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeuProjetoDeTeste
{
    public class ProdutosControllerTest
    {
        private readonly HttpClient _client;

        public ProdutosControllerTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5124");
        }

        [Fact]
        public async Task Get_ShouldReturnAllProducts()
        {
            // ...
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectProduct()
        {
            // ...
        }

        [Fact]
        public async Task Post_ShouldCreateNewProduct()
        {
            // ...
        }

        // ... outros testes
    }
}