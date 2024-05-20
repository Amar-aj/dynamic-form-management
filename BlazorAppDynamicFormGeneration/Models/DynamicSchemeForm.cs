namespace BlazorAppDynamicFormGeneration.Models;

public class DynamicSchemeForm
{
    public int Id { get; set; }
    public int SchemeId { get; set; }
    public string FieldName { get; set; }
    public string DataType { get; set; }
    public string? TabName { get; set; }
    public string? GroupName { get; set; }
    public int PositionOnTab { get; set; }
    public string? Options { get; set; }
    public string? PlaceHolder { get; set; }
    public string? DefaultValue { get; set; }
    public int MaxLength { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; } = true;
}
