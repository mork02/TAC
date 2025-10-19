namespace ActiveTwitch.Models
{
    class StreamerModel
    {
        public string Name { get; set; }
        public string ChannelUrl { get; set; }
        public bool IsLive { get; set; }
        public string GameBeingPlayed { get; set; }
        public int ViewerCount { get; set; }
    }
}
