namespace SanctionManagingBackend.DTO
{
    public class GenerateSanctionRequest
    {
        public string WordBase64 { get; set; }
        public Dictionary<string, string> Placeholders { get; set; }
    }
}
