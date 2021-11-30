using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace PdfGenerator.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HtmlToPdfGenerator : ControllerBase
	{
		[HttpGet(Name = "HtmlToPdf")]
		public FileContentResult Get(string html)
		{
			HtmlToPdf converter = new();
			converter.Options.MarginBottom = 30;
			converter.Options.MarginTop = 30;
			converter.Options.MarginLeft = 15;
			converter.Options.MarginRight = 15;

			// convert the url to pdf
			PdfDocument doc = converter.ConvertHtmlString(html);

			// save pdf document
			var res = doc.Save();

			// close pdf document
			return File(res, "application/pdf", $"{DateTime.Now:G}.pdf");
		}
	}
}
