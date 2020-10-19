using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{
    public class HashedProductBase
    {
        public virtual Guid Id { get; set; }
        public double[] Weights { get; set; }
        public int[][] Hashes { get; set; }
    }
}
