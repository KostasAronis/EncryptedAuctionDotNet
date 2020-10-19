using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{
    public class SearchQuery
    {
        public int[][] HashSeeds { get; set; }
        public IEnumerable<string> SearchTerms { get; set; }
        public double MinimumSimilarity { get; set; } = 0.5;
        public int MaxResults { get; set; } = 10;
    }
    public class HashedSearchQuery
    {
        public int[] SearchTerm { get; set; }
        public double MinimumSimilarity { get; set; } = 0.5;
        public int MaxResults { get; set; } = 10;
    }
}
