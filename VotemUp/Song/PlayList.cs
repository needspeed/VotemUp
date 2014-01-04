using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    class PlayList
    {
        private Dictionary<int, double> songspriority;
        private Dictionary<int, Song> songs;
        private DateTime createdOn;
        private String albumcover_path;

        public PlayList(String path, String albumcover_path)
        {
            this.songs = getParsedSongs(path, albumcover_path);
            songspriority = new Dictionary<int, double>();
            foreach (int i in songs.Keys) songspriority[i] = 0;
            this.createdOn = DateTime.Now;
            this.albumcover_path = albumcover_path;
        }

        public static Dictionary<int, Song> getParsedSongs(String path, String albumcover_path)
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
                        Song song = new Song(act_line, albumcover_path);
                        songs[song.getUniqueID()] = song;
                    }
                    catch (System.IO.FileNotFoundException fnfe) 
                    {
                        Console.WriteLine("File not found: " + act_line);
                        continue; 
                    } 
                    catch (TagLib.CorruptFileException cfe) 
                    {
                        Console.WriteLine("Corrupt File: " + act_line);
                        continue; 
                    }
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

        public static String createAlbumCover(TagLib.IPicture[] pics, String path)
        {
            TagLib.IPicture pic = null;
            if (pics.Length > 0)
            {
                pic = pics[0];
                try
                {
                    path = path.Replace(' ', '_');
                    String extension = "." + pic.MimeType.Split('/')[1];
                    // Open file for reading
                    if (!System.IO.File.Exists(path))
                    {                        
                        System.IO.FileStream _FileStream = new System.IO.FileStream(path + extension, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        // Writes a block of bytes to this stream using data from
                        // a byte array.
                        Byte[] arrayToWrite = pic.Data.ToArray();
                        _FileStream.Write(arrayToWrite, 0, arrayToWrite.Length);

                        // close file stream
                        _FileStream.Close();
                        return path + extension;
                    }
                    else return path + extension;
                }
                catch (System.IO.DirectoryNotFoundException dnfe)
                {
                    System.IO.Directory.CreateDirectory(path);
                    return createAlbumCover(pics, path);
                }
                catch (Exception _Exception)
                {
                    // Error
                    Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                    return null;
                }
            }
            else return null;
        }
    }
}
