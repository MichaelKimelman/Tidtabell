using Tidtabell.Models.Join_Tables;

namespace Tidtabell.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LineStops>? LineStops { get; set; }
    }
}
