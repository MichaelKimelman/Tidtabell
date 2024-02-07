namespace Tidtabell.Models.Join_Tables
{
    public class LineStops
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }
        public int StopId { get; set; }
        public Stop Stop { get; set; }

    }
}
