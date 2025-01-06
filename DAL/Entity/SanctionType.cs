using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionManagingBackend.Data.Entity
{
    public class SanctionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unieke ID voor de template
        public string Name { get; set; } // Naam van de template (bijv. "Waarschuwing niet komen opdagen")
        public string Description { get; set; } // Optioneel: Beschrijving van de template
        public string WordBase64 { get; set; } // word in base64
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Datum van aanmaak
        public DateTime? UpdatedAt { get; set; } // Datum van laatste wijziging
    }
}
