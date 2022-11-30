using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class CitusTable
    {
        public string CitusTableType { get; set; }
        public string DistributionColumn { get; set; }
        public int? ColocationId { get; set; }
        public string TableSize { get; set; }
        public long? ShardCount { get; set; }
    }
}
