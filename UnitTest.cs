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
            var response = await _client.GetAsync("/produtos");

            response.EnsureSuccessStatusCode(); 
            var produtos = await response.Content.ReadFromJsonAsync<List<Produto>>();

 
            Assert.NotNull(produtos); 
            Assert.NotEmpty(produtos); 
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectProduct()
        {
            /
            var productId = "123"; 
            var response = await _client.GetAsync($"/produtos/{productId}");

            
            response.EnsureSuccessStatusCode();
            var produto = await response.Content.ReadFromJsonAsync<Produto>();

            Assert.NotNull(produto);
            Assert.Equal(productId, produto.Id); 
        }

        [Fact]
        public async Task Post_ShouldCreateNewProduct()
        {
            var novoProduto = new Produto { Nome = "Produto Novo", Preco = 10 };
            var content = new StringContent(JsonConvert.SerializeObject(novoProduto), Encoding.UTF8, "application/json");

            
            var response = await _client.PostAsync("/produtos", content);


            response.EnsureSuccessStatusCode();
            var produtoCriado = await response.Content.ReadFromJsonAsync<Produto>();

            Assert.NotNull(produtoCriado);
            Assert.Equal(novoProduto.Nome, produtoCriado.Nome);
            Assert.Equal(novoProduto.Preco, produtoCriado.Preco);
        }

 
    }
}