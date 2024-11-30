namespace diccionario_datos.dtos.request;

public class TableDescriptionRequestDto
{
    public string schema { get; set; }
    public string table { get; set; }
    public string column { get; set; }
    public string description { get; set; }
}