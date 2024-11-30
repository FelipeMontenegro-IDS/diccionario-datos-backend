using diccionario_datos.models;

namespace diccionario_datos.repositories;

public interface ITableStructureRepository
{
    public Task<IEnumerable<TableStructure>> GetTableStructureByName(string name,string schema);
}