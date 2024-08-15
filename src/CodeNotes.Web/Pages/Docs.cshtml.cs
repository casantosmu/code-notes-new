using CodeNotes.Web.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeNotes.Web.Pages;

public class DocsModel(MarkdownFileReaderService markdownFileReaderService) : PageModel
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public string? HtmlContent { get; private set; }

    public IActionResult OnGet(string filepath)
    {
        try
        {
            var fileContent = markdownFileReaderService.ProcessMarkdownFile(filepath);
            Title = fileContent.Title;
            Description = fileContent.Description;
            HtmlContent = fileContent.HtmlContent;

            return Page();
        }
        catch (FileNotFoundException)
        {
            return NotFound();
        }
    }
}