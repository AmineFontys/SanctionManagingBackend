using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionManagingBackend.Data.Entity
{
    public class SanctionTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public Level Level { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public string StandardLetterTemplate { get; set; }
    }

    public enum Level
    {
        FirstCallForContact,
        SecondCallForContact,
        Warning,
        Suspension,
        Termination
    }
    public enum Category
    {
        CallForContact,
        NoShow,
        Late,
        General
    }
}
