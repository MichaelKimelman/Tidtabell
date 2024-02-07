namespace Tidtabell.Models.Join_Tables
{
    public class StopTimes
    {
        public int Id { get; set; }
        public int StopId { get; set; }
        public Stop Stop { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }

    }
}
