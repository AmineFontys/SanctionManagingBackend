


using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public static class WordTemplateProcessor
    {
            public static byte[] ReplacePlaceholders(byte[] docxBytes, Dictionary<string, string> placeholders)
            {
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(docxBytes, 0, docxBytes.Length);

                    // **Nieuw: Reset de positie van de stream naar het begin**
                    memoryStream.Position = 0;

                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(memoryStream, true))
                    {
                        var body = wordDoc.MainDocumentPart.Document.Body;

                        // Gebruik een dictionary om snel placeholders op te zoeken
                        var placeholderKeys = placeholders.Keys.ToList();

                        foreach (var paragraph in body.Descendants<Paragraph>())
                        {
                            foreach (var run in paragraph.Descendants<Run>())
                            {
                                foreach (var text in run.Descendants<Text>())
                                {
                                    foreach (var placeholder in placeholders)
                                    {
                                        if (text.Text.Contains(placeholder.Key))
                                        {
                                            text.Text = text.Text.Replace(placeholder.Key, placeholder.Value);
                                        }
                                    }
                                }
                            }
                        }

                        wordDoc.MainDocumentPart.Document.Save();
                    }

                    // **Optioneel: Reset de positie opnieuw als je het leesproces start**
                    memoryStream.Position = 0;

                    return memoryStream.ToArray();
                }
            }
        }
}
