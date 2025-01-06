using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionManagingBackend.Data.Entity
{
    public class Sanction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unieke ID voor de sanctie
        public int FlexworkerId { get; set; } // Verwijzing naar de flexkracht
        public Flexworker Flexworker { get; set; } // Navigatie-eigenschap naar de flexkracht
        public byte[] PdfFile { get; set; } // De volledig ingevulde brieftekst
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Datum van aanmaak
        public int EmployeeId { get; set; } // ID van de gebruiker die de sanctie heeft aangemaakt
        public Employee Employee { get; set; } // Navigatie-eigenschap naar de gebruiker
        public string SanctionType { get; set; } // Type sanctie
    }
}
