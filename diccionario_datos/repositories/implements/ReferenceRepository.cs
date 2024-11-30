using System.Data;
using Dapper;
using diccionario_datos.models;

namespace diccionario_datos.repositories.implements;

public class ReferenceRepository : IReferenceRepository
{
    private readonly IDbConnection _connection;

    public ReferenceRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<Reference>> GetAllReferencesByNameAndSchema(string name, string schema)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@name",name);
        parameters.Add("@schema",schema);
        
        return await _connection.QueryAsync<Reference>(
            "sp_tables_references",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}