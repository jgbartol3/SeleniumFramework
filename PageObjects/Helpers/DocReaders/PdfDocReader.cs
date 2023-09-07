using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;




namespace PageObjects.PageHelpers.DocReaders
{
    class PdfDocReader : BaseDocReader
    {
        public string ReadPdf(string documentTitle)
        {
            StringBuilder pdfContent = new();

            using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(SetFullFilePathAndWait(documentTitle))))
            {
                LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();

                for (int i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
                {
                    PdfPage page = pdfDocument.GetPage(i);

                    string text = PdfTextExtractor.GetTextFromPage(page, strategy);

                    pdfContent.Append(text);
                }

                pdfDocument.Close();

                pdfContent.Replace("\n", " ");
            }

            DeleteFile(documentTitle);

            return pdfContent.ToString();
        }
    }

    public class PdfReport
    {
        public string User { get; set; }

        public string ReportTitle { get; set; }
    }

}
