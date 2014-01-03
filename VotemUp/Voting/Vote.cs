using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class Vote
    {
        private Voter voter;
        private TimeSpan voteTime;

        public Vote(Voter voter, TimeSpan voteTime)
        {
            this.voter = voter;
            this.voteTime = voteTime;
        }

        public TimeSpan getVoteTime()
        {
            return voteTime;
        }

        public bool isThisVoter(Voter voter)
        {
            return this.voter.Equals(voter);
        }

        public override bool Equals(object o)
        {
            if (o is Vote)
            {
                return voter.getName().Equals(((Vote)o).voter.getName());
            }
            else return base.Equals(o);
        }
    }
}
