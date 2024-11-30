using diccionario_datos.dtos;
using diccionario_datos.dtos.request;
using diccionario_datos.models;

namespace diccionario_datos.repositories;

public interface ITableRepository
{
    public Task<IEnumerable<Table>> GetTablesByNameAndSchema(string schema);
    public Task<BaseResponseDto> AddDescripcionByColumn(TableDescriptionRequestDto request);
} 