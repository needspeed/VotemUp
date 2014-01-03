using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class PlayList
    {
        Dictionary<int, double> songspriority;
        Dictionary<int, Song> songs;
        DateTime createdOn;

        public PlayList(String path)
        {
            this.songs = getParsedSongs(path);
            songspriority = new Dictionary<int, double>();
            foreach (int i in songs.Keys) songspriority[i] = 0;
            this.createdOn = DateTime.Now;
            
        }

        public static Dictionary<int, Song> getParsedSongs(String path)
        {
            Dictionary<int, Song> songs = new Dictionary<int, Song>();
            String[] readFile = Util.readFileToArray(path);
            foreach (String line in readFile)
            {
                String act_line = line.Split('\r')[0];
                if (act_line.EndsWith(".mp3"))
                {
                    try
                    {
                        Song song = new Song(act_line);
                        songs[song.getUniqueID()] = song;
                    }
                    catch (System.IO.FileNotFoundException fnfe) { continue; } //Need better handling seriously
                    catch (Exception e) { continue; }
                }
            }
            return songs;
        }

        public Dictionary<String, double> getPlayListReadable(bool ordered=false)
        {
            Dictionary<int, Song> toIterate;
            if (ordered) toIterate = getVotedSongs();
            else toIterate = songs;

            Dictionary<String, double> readable = new Dictionary<String, double>();
            foreach (int i in toIterate.Keys)
            {
                readable[songs[i].getTitleArtistString()] = songspriority[i];                   
            }
            return readable;
        }

        public Dictionary<int, Song> getSongsByUid()
        {
            return songs;
        }

        public Dictionary<int, Song> getVotedSongs()
        {
            Dictionary<int, Song> ordered_song_list = new Dictionary<int,Song>();
            Dictionary<int, double> vote_list_to_order = new Dictionary<int, double>();
            foreach (int uid in songspriority.Keys)
            {
                if (songspriority[uid] > 0)
                {
                    vote_list_to_order[uid] = songspriority[uid];
                }
            }
            List<KeyValuePair<int, double>> myList = vote_list_to_order.ToList();

            myList.Sort((nextPair, firstPair) => firstPair.Value.CompareTo(nextPair.Value));

            foreach (KeyValuePair<int, double> kvp in myList)
            {
                ordered_song_list[kvp.Key] = songs[kvp.Key];
            }

            return ordered_song_list;

        }

        public void removeSong(int uid)
        {
            songs.Remove(uid);
            songspriority.Remove(uid);
        }

        public int getUIDofSong(String titleartist)
        {
            foreach (Song s in songs.Values)
            {
                if (s.Equals(titleartist)) return s.getUniqueID();
            }
            return -1;
        }

        public double getPrioriyOfSong(int uid)
        {
            if (uid == -1) return -1;
            return songspriority[uid];
        }

        public bool vote(int uid, Voter voter)
        {
            bool success = false;
            if (voter != null)
            {
                success = songs[uid].vote(new Vote(voter, DateTime.Now - createdOn));
                if (success) songspriority[uid] = songs[uid].getPriority();
            }
            return success;
        }
    }
}
