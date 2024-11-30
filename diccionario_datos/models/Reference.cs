namespace diccionario_datos.models;

public class Reference
{
    public string ForeignKeyName { get; set; }
    public string ParentTable { get; set; }
    public string ParentColumn { get; set; }
    public string ReferencedTable { get; set; }
    public string ReferencedColumn { get; set; }
}