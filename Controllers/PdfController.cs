using Microsoft.AspNetCore.Mvc;
using IronPdf;

namespace ironpdf_web.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        IronPdf.Logging.Logger.EnableDebugging = true;
        IronPdf.Logging.Logger.LogFilePath = "Default.log"; 
        IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;

	
		var pdfDocuments = new List<PdfDocument>();
		
		var Renderer = new ChromePdfRenderer();
		using var page1 = Renderer.RenderHtmlAsPdf("<h1>Page 1</h1>");
		page1.SaveAs("Page1.pdf");

		// pdfDocuments.Add(page1);

		// using var page2 = Renderer.RenderHtmlAsPdf("<h1>Page 2</h1>");
		// pdfDocuments.Add(page2);

		// using PdfDocument mergedDocument = IronPdf.PdfDocument.Merge(pdfDocuments);		
		// mergedDocument.SaveAs("export.pdf");

		return Ok();
	}
}
