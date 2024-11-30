using diccionario_datos.dtos;
using diccionario_datos.dtos.request;
using diccionario_datos.models;
using diccionario_datos.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diccionario_datos.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly ITableStructureRepository _tableStructureRepository;
        private readonly ISchemaRepository _schemaRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IReferenceRepository _referenceRepository;
        
        public DatabaseController(
            ITableStructureRepository tableStructureRepository,
            ISchemaRepository schemaRepository ,
            ITableRepository tableRepository,
            IReferenceRepository referenceRepository
            )
        {
            _tableStructureRepository = tableStructureRepository;
            _schemaRepository = schemaRepository;
            _tableRepository = tableRepository; 
            _referenceRepository = referenceRepository;
        }
        
        [HttpGet("tables-structure/{name}/{schema}")]
        public async Task<IEnumerable<TableStructure>> GetTablesStructure(string name,string schema)
        {   
            return await _tableStructureRepository.GetTableStructureByName(name,schema);
        }

        [HttpPost("table")]
        public async Task<BaseResponseDto> AddDescripcionTable([FromBody] TableDescriptionRequestDto request)
        {
            return await _tableRepository.AddDescripcionByColumn(request);
        }
        
        [HttpGet("tables/{schema}")]
        public async Task<IEnumerable<Table>> GetAllTablesBySchema(string schema)
        {
            return await _tableRepository.GetTablesByNameAndSchema(schema);
        }
        
        [HttpGet("schema")]
        public async Task<IEnumerable<Schema>> GetSchemas()
        {   
            return await _schemaRepository.GetAll();
        }
        
        [HttpGet("references/{name}/{schema}")]
        public async Task<IEnumerable<Reference>> GetReferencesByNameAndScheme(string name,string schema)
        {   
            return await _referenceRepository.GetAllReferencesByNameAndSchema(name,schema);
        }
    }
}
