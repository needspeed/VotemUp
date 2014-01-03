using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp
{
    static class CsInterpreter
    {
        public static String interpretCsCode(String csCode, PlayList pl, String path_of_cs_file, Dictionary<String, String> vars)
        {
            String interpreted = "";
            String[] split_at_instruction = csCode.Split(';');

            foreach (String instruction_set in split_at_instruction)
            {
                if (instruction_set.Split('(').Length == 2)
                {
                    String instruction = instruction_set.Split('(')[0];
                    String args_unparsed = instruction_set.Split('(')[1];
                    String[] args = args_unparsed.Substring(0, args_unparsed.Length - 1).Trim().Split(',');

                    instruction = instruction.Trim();
                    String directory = path_of_cs_file.Replace(path_of_cs_file.Split('/')[path_of_cs_file.Split('/').Length - 1], "");

                    //INSTRUCTIONS: ------------------------------------------------------------------------------------------------------
                    if (instruction.Equals("genList")) interpreted = genList(pl, directory + args[0].Trim(), args[1].Trim());
                    else if (instruction.Equals("getVar")) interpreted = vars[args[0].Split('$')[1]];
                    else continue;
                    //---------------------------------------------------------------------------------------------------------------------
                }
                else continue;
            }

            return interpreted;
        }

        private static String genList(PlayList pl, String html_to_load, String order)
        {
            String html = "<ul>";
            String static_html_element = new System.IO.StreamReader(html_to_load).ReadToEnd();

            Dictionary<int, Song> toIterate;
            if (order.Equals("voteordered")) toIterate = pl.getVotedSongs();
            else /* (order.Equals("unordered"))*/ toIterate = pl.getSongsByUid();

            foreach (int uid in toIterate.Keys)
            {
                Song.mp3Head info = toIterate[uid].getMP3Info();
                html += genListElement(uid, info, static_html_element);
            }
            html += "</ul>";
            return html;
        }

        private static String genListElement(int uid, Song.mp3Head info, String static_html_element)
        {
            String read_html = static_html_element;

            read_html = read_html.Replace("$ALBUM_COVER", info.picture);
            read_html = read_html.Replace("$SONG_TITLE", info.title);
            read_html = read_html.Replace("$SONG_ARTIST", info.artist);
            read_html = read_html.Replace("$SONG_DURATION", (info.duration)/60 + ":" + ((info.duration%60 > 9) ? "" : "0") + info.duration%60 );
            read_html = read_html.Replace("$SONG_UID", uid.ToString());

            return read_html;
        }
    }
}
