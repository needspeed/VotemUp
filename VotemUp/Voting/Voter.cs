using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class Voter
    {
        private String name;
        private String password;

        public Voter(String name, String password)
        {
            this.name = name;
            this.password = Util.getMD5Hash(password);
        }


       
        public String getName()
        {
            return this.name;
        }

        public bool passwordMatches(String password)
        {
            return this.password.Equals(password);
        }

        public override bool Equals(object o)
        {
            if (o is Voter)
            {
                return this.name.Equals(((Voter)o).name);
            }
            else return base.Equals(o);
        }

    }
}
