using System.ComponentModel.DataAnnotations;

namespace BaseMicroService.Abstractions.Models
{
    public abstract class BaseTestModel
    {
        [Required] [StringLength(255)] public string Name { get; set; } = string.Empty;
    }

    public class CreateTestModel : BaseTestModel
    {
    }

    public class EditTestModel : BaseTestModel
    {
    }
}
