using System.ComponentModel.DataAnnotations;

namespace DermaLogic.Models
{
    public class TestModule
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Modül ismi zorunludur.")]
        [Display(Name = "Modül Adı")]
        public string Name { get; set; } = string.Empty; 

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        public virtual ICollection<TestCase>? TestCases { get; set; }
    }
}