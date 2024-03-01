﻿namespace Tidtabell.Models.Join_Tables
{
    public class LineStops
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int StopId { get; set; }
        public int StopPosition { get; set; }
        public DateTime Time { get; set; }
        public bool Reverse { get; set; }

    }
}
