using diccionario_datos.models;

namespace diccionario_datos.repositories;

public interface IReferenceRepository
{
    public Task<IEnumerable<Reference>> GetAllReferencesByNameAndSchema(string name, string schema);
}