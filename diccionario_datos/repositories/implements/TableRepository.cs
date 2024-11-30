using System.Data;
using Dapper;
using diccionario_datos.dtos;
using diccionario_datos.dtos.request;
using diccionario_datos.models;

namespace diccionario_datos.repositories.implements;

public class TableRepository : ITableRepository
{
    private readonly IDbConnection _connection;

    public TableRepository(IDbConnection connection)
    {
        _connection = connection;   
    }
    
    public async Task<IEnumerable<Table>> GetTablesByNameAndSchema(string schema)
    {
        DynamicParameters parameters = new DynamicParameters();
        // parameters.Add("@name",name);
        parameters.Add("@schema",schema);
        return await _connection.QueryAsync<Table>(
            "sp_list_tables",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<BaseResponseDto> AddDescripcionByColumn(TableDescriptionRequestDto request)
    {
        DynamicParameters parameters = new DynamicParameters();
        
        parameters.Add("@schema",request.schema);
        parameters.Add("@table",request.table);
        parameters.Add("@column",request.column);
        parameters.Add("@description",request.description);
        
        int  result = await _connection.QuerySingleOrDefaultAsync<int>(
            "ActualizarDescripcionCampo",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        if (result != 0) return new BaseResponseDto{ Confirmation = false, Error = "Error", Message = "No se guardó correctamente." };
        
        return new BaseResponseDto{ Confirmation = true, Error = "", Message = "Se registró correctamente." };
    }
}