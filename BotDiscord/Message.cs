namespace BotDiscord
{
    public class Message
    {
        public int players_current { get; set; }
        public int players_maximum { get; set; }
        public int queue_current { get; set; }
        public int queue_wait_time_minutes { get; set; }
        public string status_enum { get; set; }
    }
}