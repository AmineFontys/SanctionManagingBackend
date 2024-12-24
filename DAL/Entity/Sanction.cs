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
        public Flexworker Flexworker { get; set; }
        [Required]
        public int FlexworkerId { get; set; }
        [Required]
        public SanctionType SanctionType { get; set; }
        [Required]
        public int SanctionTypeId { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
