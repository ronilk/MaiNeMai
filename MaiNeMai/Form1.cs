using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaiNeMai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //EVENTS TEST
        private void button1_Click(object sender, EventArgs e)
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();
            pub.myEvent += sub.CallMe;

            pub.OnEventOccurence(100);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            EnvironmentProvider.CreatePlayers(4);
            EnvironmentProvider.WireEvents();
            EnvironmentProvider.AssignPillow();
        }

        private void btnMusicStart_Click(object sender, EventArgs e)
        {
            MusicPlayer.OnMusicStart();

        }

        private void btnMusicStop_Click(object sender, EventArgs e)
        {
            MusicPlayer.OnMusicStop();
        }


    }
}
