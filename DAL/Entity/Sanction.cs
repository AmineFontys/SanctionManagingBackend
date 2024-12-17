using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionManagingBackend.Data.Entity
{
    public class Sanction
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Flexworker Flexworker { get; set; }
        [Required]
        public int FlexworkerId { get; set; }
        [Required]
        public SanctionType SanctionType { get; set; }
        [Required]
        public int SanctionTypeId { get; set; }
    }
}
