using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class UserManager
    {
        List<Voter> voters;

        public UserManager()
        {
            this.voters = new List<Voter>();
        }

        public bool addUser(Voter voter)
        {
            bool success = !voters.Contains(voter);
            if (success) voters.Add(voter);
            return success;
        }

        public Voter getUser(String user, String password)
        {
            foreach (Voter v in voters)
            {
                if (v.getName().Equals(user) && v.passwordMatches(password)) return v;
            }
            return null;
        }
    }
}
