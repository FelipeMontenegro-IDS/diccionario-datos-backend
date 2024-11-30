using System.Data;
using Dapper;
using diccionario_datos.models;

namespace diccionario_datos.repositories.implements;

public class TableStructureRepository  : ITableStructureRepository
{
    private readonly IDbConnection _connection;

    public TableStructureRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<IEnumerable<TableStructure>> GetTableStructureByName(string name,string schema)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@name",name);
        parameters.Add("@schema",schema);
        
        return await _connection.QueryAsync<TableStructure>(
            "sp_table_estructure",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}