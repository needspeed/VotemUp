using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class Song
    {
        private String path;
        private mp3Head info;
        
        private Votes votes;

        public struct mp3Head
        {        
            public String title;
            public String artist;
            public String album;
            public int duration;
            public String picture;
        }

        public Song (String path)
        {
            this.path = path;
            this.info = getMP3Info(path);
            this.votes = new Votes();
        }

        public bool vote(Vote vote)
        {
            return votes.addVote(vote);
        }

        public static mp3Head getMP3Info(String path)
        {
            mp3Head toreturn;
            TagLib.File f = TagLib.File.Create(path);
            toreturn.album = f.Tag.Album;
            toreturn.title = f.Tag.Title;
            toreturn.artist = f.Tag.JoinedPerformers;
            toreturn.duration = (int)f.Properties.Duration.TotalSeconds;
            //toreturn.picture = f.Tag.Pictures[0].Description; //ToDO getPath
            toreturn.picture = null;

            return toreturn;
        }

        public double getPriority()
        {
            return votes.getPriority();
        }

        public int getUniqueID()
        {
            return Util.getMD5HashAsInt(path);
        }

        public String getTitleArtistString()
        {
            return info.artist + " - " + info.title;
        }

        public bool Equals(object o)
        {
            if (o is String)
            {
                return getTitleArtistString().Equals(((String)o));
            }
            else return base.Equals(o);
        }

        public mp3Head getMP3Info()
        {
            return this.info;
        }

        public String getPath()
        {
            return this.path;
        }
    }
}
