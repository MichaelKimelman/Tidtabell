namespace Tidtabell.Models.Join_Tables
{
    public class LineTimes
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }

    }
}
