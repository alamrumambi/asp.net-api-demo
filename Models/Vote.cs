using System;
using System.Collections.Generic;

namespace Demo_Test.Models
{
    public partial class Vote
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VotingId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Voting Voting { get; set; }
    }
}
