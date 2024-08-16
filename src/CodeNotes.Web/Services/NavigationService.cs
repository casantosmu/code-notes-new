using System.Text.Json;

using Microsoft.Extensions.Caching.Memory;

namespace CodeNotes.Web.Services;

public record NavItem(string Name, string? Href, List<NavItem>? Links);

public class NavigationService(IMemoryCache memoryCache)
{
    private static readonly string CacheKey = "NavigationCacheKey";

    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public List<NavItem> GetNavigation()
    {
        var cachedContent = memoryCache.Get<List<NavItem>>(CacheKey);
        if (cachedContent is not null)
        {
            return cachedContent;
        }

        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "navigation.json");
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("Navigation file not found.", fullPath);
        }

        var json = File.ReadAllText(fullPath);

        var navigation = JsonSerializer.Deserialize<List<NavItem>>(json, JsonSerializerOptions) ??
            throw new InvalidOperationException("Failed to deserialize navigation data.");

        var cacheEntryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);
        memoryCache.Set(CacheKey, navigation, cacheEntryOptions);

        return navigation;
    }
}