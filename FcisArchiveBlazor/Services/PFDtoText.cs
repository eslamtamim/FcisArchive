using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace TESTDOM.Services

{
	public static class PDFtoText
	{
		public static string pdfText(string path)
		{
			PdfReader reader = new PdfReader(path);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			return text;
		}
	}
}