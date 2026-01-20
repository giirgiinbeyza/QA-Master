using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DermaLogic.Models
{
    public class TestCase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Test başlığı zorunludur.")]
        [Display(Name = "Test Senaryosu")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Test Adımları")]
        public string? Steps { get; set; }

        [Display(Name = "Öncelik")]
        public string Priority { get; set; } = "Orta";

        [Display(Name = "Son Durum")]
        public string Status { get; set; } = "Koşulmadı";

        [Display(Name = "Tarih")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Modül")]
        public int TestModuleId { get; set; }

        public virtual TestModule? TestModule { get; set; }

        public string? ImagePath { get; set; }
        public string? TestType { get; set; }
        public string? ExpectedResult { get; set; }

        public string? AssignedTo { get; set; }
        
    }
}
