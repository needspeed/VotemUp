using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class Votes
    {
        const int VOTE_PRIORITY = 3;

        List<Vote> votes;

        public Votes()
        {
            votes = new List<Vote>();
        }


        public Boolean addVote(Vote vote)
        {
            bool exists = votes.Contains(vote);
            if (!exists) votes.Add(vote);
            return !exists;
        }

        public int getVotesCount()
        {
            return votes.Count;
        }

        public double getPriority()
        {
            TimeSpan addtime = new TimeSpan(0);
            foreach (Vote vote in votes) addtime += vote.getVoteTime();

            int totalseconds = (int)addtime.TotalSeconds;
            int votecount = getVotesCount();

            double priority = (double)1/totalseconds + votecount * VOTE_PRIORITY;

            return priority;
        }
    }
}
