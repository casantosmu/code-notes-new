using System.Text.RegularExpressions;

using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace CodeNotes.Web.Lib;

public static partial class MarkdownProcessor
{
    private const int MinDescriptionLength = 50;
    private const int MaxDescriptionLength = 160;

    [GeneratedRegex(@"^---.*\ndescription:\s*(.*?)\n", RegexOptions.Singleline)]
    private static partial Regex FrontMatterDescriptionRegexp();

    public static string ExtractH1(string markdown)
    {
        var markdownPipeline = new MarkdownPipelineBuilder().Build();
        var document = Markdown.Parse(markdown, markdownPipeline);

        foreach (var headingBlock in document.Descendants<HeadingBlock>())
        {
            if (headingBlock.Level == 1 && headingBlock.Inline?.FirstChild is LiteralInline literalInline)
            {
                return literalInline.Content.ToString();
            }
        }

        throw new InvalidOperationException("The markdown file does not contain a level 1 heading.");
    }

    public static string ExtractFrontMatterDescription(string markdown, bool validate = false)
    {
        var match = FrontMatterDescriptionRegexp().Match(markdown);
        var description = match.Success ? match.Groups[1].Value.Trim(' ', '"') : string.Empty;

        if (string.IsNullOrEmpty(description))
        {
            throw new InvalidOperationException("The markdown file does not contain a valid meta description.");
        }

        if (validate)
        {
            if (description.Length < MinDescriptionLength)
            {
                throw new InvalidOperationException($"The description is too short ({description.Length} characters). Minimum allowed is {MinDescriptionLength} characters.");
            }

            if (description.Length > MaxDescriptionLength)
            {
                throw new InvalidOperationException($"The description is too long ({description.Length} characters). Maximum allowed is {MaxDescriptionLength} characters.");
            }
        }

        return description;
    }

    public static string MarkdownToHtml(string markdown)
    {
        var markdownPipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseYamlFrontMatter()
            .Build();
        return Markdown.ToHtml(markdown, markdownPipeline);
    }
}