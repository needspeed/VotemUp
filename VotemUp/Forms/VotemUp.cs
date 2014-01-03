using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotemUp.HTTP;
using System.Threading;

namespace VotemUp
{
    public partial class VotemUp : Form
    {
        const int HTTP_PORT = 9987;

        String masterpw = "";
        PlayList pl;
        UserManager um;
        MyHttpServer httpServer;
        Thread httpThread;

        public VotemUp()
        {
            InitializeComponent();

            this.um = new UserManager();
        }

        // Events: -------------------------------------------------------------------------------------------------

        private void pathOfPlayerButton_Click(object sender, EventArgs e)
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                path = ofd.FileName;
                if (!path.EndsWith(".exe"))
                {
                    MessageBox.Show("You did not specify a valid executable!");
                }
                else changePlayerPath(path);
            }
        }

        private void pathofPlaylistButton_Click(object sender, EventArgs e)
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                path = ofd.FileName;
                if (!path.EndsWith(".playlist"))
                {
                    MessageBox.Show("You did not specify a valid playlist!");
                }
                else changePlaylistPath(path);
            }
        }


        private void playListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            voteListBox.SelectedIndex = playListBox.SelectedIndex;
            int uid = pl.getUIDofSong((String)playListBox.SelectedItem);
            textBox1.Text = uid.ToString();
            textBox2.Text = pl.getPrioriyOfSong(uid).ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //pl.vote(Convert.ToInt32(textBox1.Text), um.getUser("Janni", Util.getMD5Hash("asdf")));
            List<KeyValuePair<String, double>> myList = pl.getPlayListReadable().ToList();

            myList.Sort((nextPair, firstPair) => firstPair.Value.CompareTo(nextPair.Value));

            Dictionary<String, double> ordered = new Dictionary<string, double>();
            foreach (KeyValuePair<String, double> kvp in myList)
            {
                ordered[kvp.Key] = pl.getPlayListReadable()[kvp.Key];
            }
            displayVotedPlaylist(ordered);
        }


        private void startServerButton_Click(object sender, EventArgs e)
        {
            httpServer = new MyHttpServer(HTTP_PORT, um, pl);
            this.httpThread = new Thread(new ThreadStart(httpServer.listen));
            this.httpThread.Start();

            startServerButton.Enabled = false;
            startServerButton.Text = "Server running";
        }



        private void daemonButton_Click(object sender, EventArgs e)
        {
            songTimer.Enabled = !songTimer.Enabled;
            daemonButton.Text = (songTimer.Enabled) ? "Stop Daemon" : "Start Daemon";
        }



        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (masterpw.Equals(masterPwBox.Text))
            {
                if (!um.addUser(new Voter(userBox.Text, passwordBox.Text)))
                {
                    MessageBox.Show("User is already existing!", "Error");
                }
                else
                {
                    userList.Items.Add(userBox.Text);
                    userBox.Text = "";
                    passwordBox.Text = "";
                    masterPwBox.Text = "";
                    MessageBox.Show("Successfully added User!", "Success");
                }
            }
            else MessageBox.Show("Master Password is wrong!", "Error");
        }


        private void changeMasterButton_Click(object sender, EventArgs e)
        {
            if (masterpw.Equals(currentMasterBox.Text))
            {
                masterpw = newMasterBox.Text;
                currentMasterBox.Text = "";
                newMasterBox.Text = "";
                MessageBox.Show("Successfully changed Master Password!", "Success");
            }
            else MessageBox.Show("Current Master Password is wrong!", "Error");
        }


        private void songTimer_Tick(object sender, EventArgs e)
        {
            String app = pathOfPlayerBox.Text;
            
            Song next = getNextSongToPlay();
            String song = next.getPath();
            String param = addBox.Text + "  \"" + song + "\"";

            System.Diagnostics.Process.Start(app, param);

            songTimer.Interval = next.getMP3Info().duration * 1000;

            pl.removeSong(next.getUniqueID());
        }


        // END Events: -----------------------------------------------------------------------------------------------

        private void changePlayerPath(String path)
        {
            pathOfPlayerBox.Text = path;
        }


        private void changePlaylistPath(String path)
        {
            //TODO parsing
            pathofplayListBox.Text = path;
        }

        private String getPlaylistPath()
        {
            return pathofplayListBox.Text;
        }

        private void displayVotedPlaylist(Dictionary<String, double> songvotes)
        {
            playListBox.Items.Clear();
            voteListBox.Items.Clear();
            foreach (String s in songvotes.Keys)
            {
                playListBox.Items.Add(s);
                voteListBox.Items.Add(songvotes[s]);
            }
        }

        private Song getNextSongToPlay()
        {
            foreach (int uid_of_first in pl.getVotedSongs().Keys) 
            {
                return pl.getSongsByUid()[uid_of_first];
            }
            foreach (int uid_of_first in pl.getSongsByUid().Keys) 
            {
                return pl.getSongsByUid()[uid_of_first];
            }
            return null;
        }

        private void loadPlaylistButton_Click(object sender, EventArgs e)
        {
            this.pl = new PlayList(getPlaylistPath());
            displayVotedPlaylist(pl.getPlayListReadable());
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            httpServer.stopServer();
            //if (httpThread != null) httpThread.Abort();
            Environment.Exit(0);
        }

    }
}
