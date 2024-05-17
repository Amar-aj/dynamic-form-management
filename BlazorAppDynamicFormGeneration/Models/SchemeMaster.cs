using System.ComponentModel.DataAnnotations;

namespace BlazorAppDynamicFormGeneration.Models;

public class SchemeMaster
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
}
public class SchemeMasterInsert
{
    [Required]
    public string Name { get; set; }
}
