[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    public ProdutosController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> Get()
    {
        var produtos = await _mongoDBService.ObterTodos();
        return produtos;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> Get(string id)
    {
        var produto = await _mongoDBService.ObterPorId(id);

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Post(Produto produto)
    {
        await _mongoDBService.Criar(produto);
        return CreatedAtAction("Get", new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        await _mongoDBService.Atualizar(produto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.Deletar(id);
        return NoContent();
    }
}