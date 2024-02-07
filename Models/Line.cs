using Tidtabell.Models.Join_Tables;

namespace Tidtabell.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public int Number { get; set; }

        public List<LineStops> LineStops { get; set; }
        public List<LineTimes> LineTimes { get; set; }
    }
}
