using CodeNotes.Web.Lib;

using Microsoft.Extensions.Caching.Memory;

namespace CodeNotes.Web.Services;

public record MarkdownFileContent(string Title, string Description, string HtmlContent);

public class MarkdownFileReaderService(IMemoryCache memoryCache)
{
    public MarkdownFileContent ProcessMarkdownFile(string filepath)
    {
        var cachedContent = memoryCache.Get<MarkdownFileContent>(filepath);
        if (cachedContent is not null)
        {
            return cachedContent;
        }

        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs", $"{filepath}.md");
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"File not found: {fullPath}");
        }

        var markdown = File.ReadAllText(fullPath);

        var title = MarkdownProcessor.ExtractH1(markdown);
        var description = MarkdownProcessor.ExtractFrontMatterDescription(markdown, true);
        var htmlContent = MarkdownProcessor.MarkdownToHtml(markdown);

        var fileContent = new MarkdownFileContent(title, description, htmlContent);

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.NeverRemove);

        memoryCache.Set(filepath, fileContent, cacheEntryOptions);

        return fileContent;
    }
}