using System.Data;
using Dapper;
using diccionario_datos.models;

namespace diccionario_datos.repositories.implements;

public class SchemaRepository : ISchemaRepository
{
    private readonly IDbConnection _connection;

    public SchemaRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<Schema>> GetAll()
    {
        return await _connection.QueryAsync<Schema>(
            "sp_list_schemas",
            commandType: CommandType.StoredProcedure
        );
    }
}