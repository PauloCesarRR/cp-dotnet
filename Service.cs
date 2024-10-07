public class MongoDBService
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoDBService(IConfiguration configuration)
    {
        _client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = _client.GetDatabase(configuration["DatabaseName"]);   

    }


    public async Task<List<Produto>> ObterTodos()
    {
        var collection = _database.GetCollection<Produto>("Produtos");
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<Produto> ObterPorId(string id)
    {
        var collection = _database.GetCollection<Produto>("Produtos");
        var objetoId = new ObjectId(id);
        return await collection.Find(x => x.Id == objetoId).FirstOrDefaultAsync();
    }

    public async Task Criar(Produto produto)
    {
        var collection = _database.GetCollection<Produto>("Produtos");
        await collection.InsertOneAsync(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        var collection = _database.GetCollection<Produto>("Produtos");
        await collection.ReplaceOneAsync(x => x.Id == produto.Id, produto);
    }

    public async Task Deletar(string id)
    {
        var collection = _database.GetCollection<Produto>("Produtos");
        var objetoId = new ObjectId(id);
        await collection.DeleteOneAsync(x => x.Id == objetoId);
    }
}
