using diccionario_datos.models;

namespace diccionario_datos.repositories;

public interface ISchemaRepository
{
    
    public Task<IEnumerable<Schema>> GetAll();
}