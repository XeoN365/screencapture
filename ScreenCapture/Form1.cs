using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread thr;
        Image[] frames;
        private void button1_Click(object sender, EventArgs e)
        {
            frames = new Image[600];
            thr = new Thread( new ThreadStart(UpdateScreen));
            thr.Start();
        }

        public void UpdateScreen()
        {
            while(true)
            {
                getImage();
            }
        }

        public void getImage()
        {
            
            int screenWidth = SystemInformation.VirtualScreen.Width + 720;
            int screenHeight = SystemInformation.VirtualScreen.Height + 480;
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;


            Bitmap bitmap = new Bitmap(screenWidth, screenHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(screenLeft, screenTop, 0, 0, new Size(screenWidth, screenHeight));

            pictureBox1.Image = (Image)bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thr.Abort();
        }
    }
}
