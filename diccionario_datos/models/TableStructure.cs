namespace diccionario_datos.models;

public class TableStructure
{
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public string DataType { get; set; }
    public string MaxLength { get; set; }
    public string IsNullable { get; set; }
    public string DefaultValue { get; set; }
    public string ColumnDescription { get; set; }
    public string IsPrimaryKey { get; set; }
    public string IsForeignKey { get; set; }
    public string SchemaName { get; set; }
}