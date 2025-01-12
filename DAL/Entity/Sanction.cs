using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionManagingBackend.Data.Entity
{
    public class Sanction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int FlexworkerId { get; set; }
        [Required]
        public Flexworker Flexworker { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public int SanctionTemplateId { get; set; }
        [Required]
        public SanctionTemplate SanctionTemplate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public byte[] PdfFile { get; set; }

    }
}
