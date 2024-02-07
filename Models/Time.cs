using Tidtabell.Models.Join_Tables;

namespace Tidtabell.Models
{
    public class Time
    {
        public int Id { get; set; }
        public DateTime ClockTime { get; set; }

        public List<LineTimes> LineTimes { get; set; }
        public List<StopTimes> StopTimes { get; set; }

    }
}
