namespace ActiveTwitch.Models
{
    public record Streamer (
        string Id,
        string Login,
        string DisplayName)
    {
        public bool IsLive { get; set; }
        public DateTimeOffset LastStatusChangeUtc { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? LiveStartedAtUtc { get; set; }

        public string? Title { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public Uri Url => new($"https://twitch.tv/{Login}");

        public void ApplyOnline(DateTimeOffset startedAt, string? title = null, string? categoryId = null, string? categoryName = null)
        {
            IsLive = true;
            LiveStartedAtUtc = startedAt;
            Title = title;
            CategoryId = categoryId;
            CategoryName = categoryName;
            LastStatusChangeUtc = DateTimeOffset.UtcNow;
        }

        public void ApplyOffline()
        {
            IsLive = false;
            LiveStartedAtUtc = null;
            LastStatusChangeUtc = DateTimeOffset.UtcNow;
        }
    }
}
