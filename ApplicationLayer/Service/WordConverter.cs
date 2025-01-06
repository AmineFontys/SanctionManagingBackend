using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace SanctionManagingBackend.ApplicationLayer.Service
{
    public class WordConverter
    {
        public byte[] ConvertDocxToPdf(byte[] docxBytes)
        {
            // Maak tijdelijke bestanden aan
            string tempDocxPath = Path.Combine(Path.GetTempPath(), $"temp-{Guid.NewGuid()}.docx");
            string tempPdfPath = Path.ChangeExtension(tempDocxPath, ".pdf");

            Application wordApp = null;
            Document doc = null;

            try
            {
                // Schrijf de DOCX bytes naar het tijdelijke DOCX-bestand
                File.WriteAllBytes(tempDocxPath, docxBytes);

                // Initialiseer de Word applicatie
                wordApp = new Application
                {
                    Visible = false,
                    ScreenUpdating = false,
                    DisplayAlerts = WdAlertLevel.wdAlertsNone
                };

                // Open het DOCX-bestand
                object readOnly = true;
                object isVisible = false;
                object missing = Type.Missing;

                doc = wordApp.Documents.Open(tempDocxPath, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);

                // Exporteer het document als PDF
                doc.ExportAsFixedFormat(
                    OutputFileName: tempPdfPath,
                    ExportFormat: WdExportFormat.wdExportFormatPDF,
                    OpenAfterExport: false,
                    OptimizeFor: WdExportOptimizeFor.wdExportOptimizeForPrint,
                    Range: WdExportRange.wdExportAllDocument,
                    From: 0,
                    To: 0,
                    Item: WdExportItem.wdExportDocumentContent,
                    IncludeDocProps: true,
                    KeepIRM: true,
                    CreateBookmarks: WdExportCreateBookmarks.wdExportCreateWordBookmarks,
                    DocStructureTags: true,
                    BitmapMissingFonts: true,
                    UseISO19005_1: false
                );

                // Lees de PDF bytes
                byte[] pdfBytes = File.ReadAllBytes(tempPdfPath);

                return pdfBytes;
            }
            finally
            {
                // Sluit het document
                if (doc != null)
                {
                    doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                    Marshal.ReleaseComObject(doc);
                }

                // Sluit de Word applicatie
                if (wordApp != null)
                {
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }

                // Verwijder de tijdelijke bestanden
                if (File.Exists(tempDocxPath))
                {
                    File.Delete(tempDocxPath);
                }
                if (File.Exists(tempPdfPath))
                {
                    File.Delete(tempPdfPath);
                }

                // Forceer garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
