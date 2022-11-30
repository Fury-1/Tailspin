using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class Chunk1
    {
        public long? StorageId { get; set; }
        public long? StripeNum { get; set; }
        public int? AttrNum { get; set; }
        public int? ChunkGroupNum { get; set; }
        public byte[] MinimumValue { get; set; }
        public byte[] MaximumValue { get; set; }
        public long? ValueStreamOffset { get; set; }
        public long? ValueStreamLength { get; set; }
        public long? ExistsStreamOffset { get; set; }
        public long? ExistsStreamLength { get; set; }
        public int? ValueCompressionType { get; set; }
        public int? ValueCompressionLevel { get; set; }
        public long? ValueDecompressedLength { get; set; }
        public long? ValueCount { get; set; }
    }
}
