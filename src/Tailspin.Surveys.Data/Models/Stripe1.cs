using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class Stripe1
    {
        public long? StorageId { get; set; }
        public long? StripeNum { get; set; }
        public long? FileOffset { get; set; }
        public long? DataLength { get; set; }
        public int? ColumnCount { get; set; }
        public int? ChunkRowCount { get; set; }
        public long? RowCount { get; set; }
        public int? ChunkGroupCount { get; set; }
        public long? FirstRowNumber { get; set; }
    }
}
